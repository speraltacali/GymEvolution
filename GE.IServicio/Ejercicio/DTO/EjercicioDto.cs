using GE.Dominio.Entity.Enums;
using GE.Servicio.Base;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Ejercicio.DTO
{
    public class EjercicioDto : BaseDto
    {
        public string Nombre { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }

        public Musculo Musculo { get; set; }
        public IFormFile Foto { get; set; }
        public string FotoLink { get; set; }


        public long RutinaId { get; set; }


    }
}
