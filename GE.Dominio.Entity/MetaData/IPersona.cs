using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml;
using GE.Dominio.Entity.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GE.Dominio.Entity.MetaData
{
    public interface IPersona
    {
        //SACAR MAIL DE LAS ENTIDADES

        [DisplayName("Apellido del asociado")]
        [Required(AllowEmptyStrings = false , ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150,ErrorMessage = "El campo {1} es obligatorio")]
        string Apellido { get; set; }


        [DisplayName("Nombre del asociado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(150, MinimumLength = 4,ErrorMessage = "El campo {1} es obligatorio")]
        string Nombre { get; set; }

        [DisplayName("Numero de Documento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(15, ErrorMessage = "El campo {1} es obligatorio")]
        string Dni { get; set; }

        [DisplayName("Domicilio del asociado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(300, ErrorMessage = "El campo {1} es obligatorio.")]
        string Domicilio{ get; set; }

        //Pasar los datos de DateTime a Date

        [DisplayName("Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        DateTime FechaNacimiento { get; set; }

        [DisplayName("Telefono del asociado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        string Telefono { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Enums.Sexo))]
        Sexo Sexo { get; set; }


        [DisplayName("Grupo Sanguineo del asociado")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El campo {0} es obligatorio.")]
        [EnumDataType(typeof(Enums.GrupoSanguineo))]
        GrupoSanguineo GrupoSanguineo { get; set; }

        [DisplayName("Fecha de Ingreso")]
        [DataType(DataType.Date)]
        DateTime FechaIngreso{ get; set; }

    }
}
