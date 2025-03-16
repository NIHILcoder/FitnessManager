using Org.BouncyCastle.Crypto.Generators;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FitnessManager
{
    public static class SecurityServices
    {
        // Ключ шифрования для AES (в реальном приложении должен храниться безопасно)
        private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("ActiveLifeSecKey"); // должен быть 16, 24, или 32 байт

        /// <summary>
        /// Хеширует пароль с использованием BCrypt
        /// </summary>
        /// <param name="password">Пароль для хеширования</param>
        /// <returns>BCrypt хеш пароля</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        /// <summary>
        /// Проверяет соответствие пароля хешу
        /// </summary>
        /// <param name="password">Пароль для проверки</param>
        /// <param name="hashedPassword">Хешированный пароль</param>
        /// <returns>true, если пароль соответствует хешу</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        /// <summary>
        /// Шифрует данные с использованием AES
        /// </summary>
        /// <param name="plainText">Текст для шифрования</param>
        /// <returns>Зашифрованные данные в формате Base64</returns>
        public static string EncryptData(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return plainText;

            byte[] iv = new byte[16]; // Инициализационный вектор
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(iv);
            }

            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKey;
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Сначала записываем IV, чтобы он был доступен при расшифровке
                    memoryStream.Write(iv, 0, iv.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        /// <summary>
        /// Расшифровывает данные, зашифрованные с помощью AES
        /// </summary>
        /// <param name="cipherText">Зашифрованные данные в формате Base64</param>
        /// <returns>Расшифрованный текст</returns>
        public static string DecryptData(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            byte[] fullCipher = Convert.FromBase64String(cipherText);

            // Проверяем, что размер достаточно большой, чтобы содержать IV
            if (fullCipher.Length < 16)
                throw new ArgumentException("Зашифрованные данные имеют неверный формат");

            // Извлекаем IV из начала зашифрованных данных
            byte[] iv = new byte[16];
            byte[] cipher = new byte[fullCipher.Length - 16];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = EncryptionKey;
                aes.IV = iv;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(cipher))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}