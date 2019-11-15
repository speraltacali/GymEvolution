using GE.Servicio.Base;
using Microsoft.AspNetCore.Http;

namespace GE.IServicio.Ejercicio.DTO
{
    public class EjercicioDto : BaseDto
    {
        public string Nombre { get; set; }
        public int Repeticiones { get; set; }
        public int Serie { get; set; }
        public IFormFile Foto { get; set; }
        public string FotoLink { get; set; }


        public long RutinaId { get; set; }


    }
}
