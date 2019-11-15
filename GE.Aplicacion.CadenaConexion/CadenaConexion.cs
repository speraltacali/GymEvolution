using System;

namespace GE.Aplicacion.CadenaConexion
{
    public class CadenaConexion
    {


        public const string DataBase = "GymEvolutionDB2019";


        public const string Server = @"tcp:gymevolutiondbserver.database.windows.net";



        public const string User = "softgym@gymevolutiondbserver";

        public const string Password = " GYM2019soft";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     //$"Integrated Security=true"; +
                                                     $"User Id={User};" +
                                                     $"Password={Password};";
    }

    /*

    public const string DataBase = "GymEvolutionDB2019";


        public const string Server = @"tcp:gymevolutiondbserver.database.windows.net";


        public const string User = "softgym@gymevolutiondbserver";

        public const string Password = " GYM2019soft";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     //$"Integrated Security=true"; +
                                                     $"User Id={User};" +
                                                     $"Password={Password};";

    */
}
