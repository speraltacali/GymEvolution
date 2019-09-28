using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {
        public const string DataBase = "GymEvolution";

        public const string Server = @"DESKTOP-NK0OJF1\SQLSANTI";

        public const string User = "sa";

        public const string Password = "Santi42175";

        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"User Id={User};" +
                                                     $"Password={Password};";
    }
}
