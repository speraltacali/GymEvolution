using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace GE.Servicio.DatosEstaticos.Session
{
    public static class SessionActiva
    {
        public static long EmpleadoId { get; set; }

        public static long ClienteId { get; set; }

        public static long UsuId { get; set; }

        public static string ApyNom { get; set; }

        public static byte[] Foto { get; set; }
    }
}
