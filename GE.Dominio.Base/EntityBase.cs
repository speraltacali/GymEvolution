using System;
using System.ComponentModel.DataAnnotations;


namespace GE.Dominio.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
