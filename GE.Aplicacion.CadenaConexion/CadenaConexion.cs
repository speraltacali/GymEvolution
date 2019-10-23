using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "GymEvolution";


        public const string Server = @"DESKTOP-NK0OJF1";


        //public const string User = "sa";

        //public const string Password = "santi42175";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";

        /*    $"User Id={User};" +
            $"Password={Password};";*/
    }
}
