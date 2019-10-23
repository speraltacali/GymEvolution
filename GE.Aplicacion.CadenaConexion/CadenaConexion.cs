using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "GymVersion15";


        public const string Server = @"DESKTOP-066FGIK";


        //public const string User = "sa";

        //public const string Password = "santi42175";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";

        /*    $"User Id={User};" +
            $"Password={Password};";*/
    }
}
