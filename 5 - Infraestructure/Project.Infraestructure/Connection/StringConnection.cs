using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Infraestructure.Connection
{
    public static class StringConnection
    {
        private const string Server = @"DESKTOP-0VUTJNI";
        private const string DataBase = "ProyectPablo";
        private const string User = "sa";
        private const string Password = "154152488";

        public static string GetConnectionStringSql => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"User Id={User}; " +
                                                       $"Password={Password};";
        public static string GetConnectionStringWin => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"Integrated Security = true";
    }
}
