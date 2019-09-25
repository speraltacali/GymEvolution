using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Repositorio.Factura;
using GE.Repositorio;

namespace GE.Infraestructura.Repositorio.Factura
{
    public class FacturaRepositorio : Repositorio<Dominio.Entity.Entidades.Factura> , IFacturaRepositorio
    {
    }
}
