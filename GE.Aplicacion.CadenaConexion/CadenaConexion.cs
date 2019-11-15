using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "GymEvolution";


        public const string Server = @"DESKTOP-UN68R9V";



        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";

        /*    $"User Id={User};" +
            $"Password={Password};";*/
    }
}
