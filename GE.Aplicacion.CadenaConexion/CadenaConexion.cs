using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "GymEvolution";


        public const string Server = @"DESKTOP-NK0OJF1";


        public const string User = "softgym@gymevolutiondbserver";

        public const string Password = " GYM2019soft";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";
    }

}

