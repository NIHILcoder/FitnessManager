using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessManager
{
    public static class DBConnection
    {
        // Строка подключения к базе данных
        public static string ConnectionString = "Host=localhost;Port=5432;Database=fitnessclub;Username=postgres;Password=1;";
    }
}