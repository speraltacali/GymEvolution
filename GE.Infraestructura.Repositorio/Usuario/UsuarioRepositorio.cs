using System;
using System.Collections.Generic;
using System.Text;
using GE.Dominio.Repositorio.Usuario;
using GE.Repositorio;

namespace GE.Infraestructura.Repositorio.Usuario
{
    public class UsuarioRepositorio : Repositorio<Dominio.Entity.Entidades.Usuario> , IUsuarioRepositorio
    {
    }
}
