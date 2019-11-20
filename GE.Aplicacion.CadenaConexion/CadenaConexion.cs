using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "XXX7";


        public const string Server = @"DESKTOP-066FGIK\SQLEXPRESS";


        public const string User = "softgym";

        public const string Password = " GYM2019soft";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";
    }
}

