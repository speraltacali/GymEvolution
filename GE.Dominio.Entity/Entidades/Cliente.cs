using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GE.Dominio.Base;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Entity.Enums;
using Microsoft.AspNetCore.Http;

namespace GE.Dominio.Entity
{
    [Table("Persona_Cliente")]
    public class Cliente : Persona
    {

        public GrupoSanguineo GrupoSanguineo { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public Estado Estado { get; set; }

        //******************************************************//

        public virtual ICollection<Cuota> Cuotas { get; set; }

        public virtual ICollection<ClienteControl> ClienteControl { get; set; }

    }
}
