﻿using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {
        public const string DataBase = "GymEvolution";

        public const string Server = @"DESKTOP-UN68R9V";

        public const string User = "sa";

        public const string Password = "santi42175";

        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"User Id={User};" +
                                                     $"Password={Password};";
    }
}
