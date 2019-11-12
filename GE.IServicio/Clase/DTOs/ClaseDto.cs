using System;
using System.Collections.Generic;
using System.Text;
using GE.Servicio.Base;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Clase.DTOs
{
    public class ClaseDto : BaseDto
    {
        public string Nombre { get; set; }

        public string  Descripcion { get; set; }

        public IFormFile Foto { get; set; }

        public string FotoLink { get; set; }

        public List<ClaseDetalleDto> ClaseDetalle { get; set; }
    }
}
