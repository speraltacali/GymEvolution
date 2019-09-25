using System;

namespace GE.Servicio.Base
{
    public class BaseDto
    {
        public long Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
