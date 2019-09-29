using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Usuario.DTO;

namespace GE.IServicio.Usuario
{
    public interface IUsuarioServicio
    {
        UsuarioDto Agregar(long id);

        UsuarioDto Modificar(UsuarioDto dto);

        void Eliminar(long id);

        IEnumerable<UsuarioDto> ObtenerTodo();

        UsuarioDto ObtenerPorId(long id);

        void Bloquear(long id);

        bool VerificarAcceso(string user, string pass);

        bool VerificarExisteUsuario();

        bool VerificarEmpleadoUsuario(long id);

        UsuarioDto ObtenerPorIdEmpleado(long id)
    }
}
