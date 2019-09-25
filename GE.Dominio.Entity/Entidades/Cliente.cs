﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GE.Dominio.Base;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Entity.Enums;

namespace GE.Dominio.Entity
{
    [Table("Cliente")]
    public class Cliente : Persona
    {

        public GrupoSanguineo GrupoSanguineo { get; set; }

        public DateTime FechaDeIngreso { get; set; }

        public DateTime FechaVencimineto { get; set; }


        //******************************************************//

        public virtual ICollection<Factura> Factura { get; set; }

    }
}
