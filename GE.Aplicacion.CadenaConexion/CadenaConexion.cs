using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {
        public const string DataBase = "GymVersion3";

        public const string Server = @"DESKTOP-066FGIK\SQLEXPRESS";
        /*
        public const string User = "sa";

        public const string Password = "Santi42175";*/

        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";
    }
}
