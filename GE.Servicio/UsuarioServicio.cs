using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity.Entidades;
using GE.Dominio.Repositorio.Empleado;
using GE.Dominio.Repositorio.Usuario;
using GE.Infraestructura.Repositorio.Empleado;
using GE.Infraestructura.Repositorio.Usuario;
using GE.IServicio.Usuario;
using GE.IServicio.Usuario.DTO;
using GE.Servicio.DatosEstaticos.Session;

namespace GE.Servicio
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioServicio = new UsuarioRepositorio();
        private readonly IEmpleadoRepositorio _empleadoServicio = new EmpleadoRepositorio();

        public UsuarioDto Agregar(long id)
        {
            var empleado = _empleadoServicio.ObtenerPorId(id);

            var usuario = new Usuario
            {
                UserName = empleado.Apellido,
                Password = empleado.Dni,
                EstaBloqueado = false,
                EmpleadoId = empleado.Id,
            };

            _usuarioServicio.Agregar(usuario);
            _usuarioServicio.Guardar();

            return new UsuarioDto()
            {
                UserName = usuario.UserName,
                Password = usuario.Password,
                EstaBloqueado = false,
                EmpleadoId = usuario.EmpleadoId
            };
        }

        public UsuarioDto Modificar(UsuarioDto dto)
        {
            var usuario = _usuarioServicio.ObtenerPorId(dto.Id);

            usuario.Password = dto.Password;

            _usuarioServicio.Modificar(usuario);
            _usuarioServicio.Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var usuario = _usuarioServicio.ObtenerPorId(id);

            if (usuario != null)
            {
                _usuarioServicio.Eliminar(id);
                _usuarioServicio.Guardar();
            }
        }

        public IEnumerable<UsuarioDto> ObtenerTodo()
        {
            return _usuarioServicio.ObtenerTodo()
                .Select(x=>new UsuarioDto()
                {
                    UserName = x.UserName,
                    Password = x.Password,
                    EstaBloqueado = x.EstaBloqueado,
                    EmpleadoId = x.EmpleadoId
                }).ToList();
        }

        public UsuarioDto ObtenerPorId(long id)
        {
            var usuario = _usuarioServicio.ObtenerPorId(id);

            return new UsuarioDto()
            {
                UserName = usuario.UserName,
                Password = usuario.Password,
                EstaBloqueado = usuario.EstaBloqueado,
                EmpleadoId = usuario.EmpleadoId
            };
        }

        public UsuarioDto ObtenerPorIdEmpleado(long id)
        {
            var usuario = _usuarioServicio.ObtenerPorFiltro(x => x.EmpleadoId == id);

            return new UsuarioDto()
            {
                UserName = usuario.FirstOrDefault().UserName,
                Password = usuario.FirstOrDefault().Password,
                EstaBloqueado = usuario.FirstOrDefault().EstaBloqueado,
                EmpleadoId = usuario.FirstOrDefault().EmpleadoId
            };
        }

        public void Bloquear(long id)
        {
            var usuario = _usuarioServicio.ObtenerPorId(id);

            usuario.EstaBloqueado = true;

            _usuarioServicio.Modificar(usuario);
            _usuarioServicio.Guardar();
        }

        public bool VerificarAcceso(string user, string pass)
        {
            bool aux = false;

            var validacion = _usuarioServicio.ObtenerPorFiltro(x =>
                x.UserName == user && x.Password == pass && x.EstaBloqueado == false);

            if (validacion.Count() >= 1)
            {
                aux = true;
                var empleado = _empleadoServicio.ObtenerPorId(validacion.FirstOrDefault().EmpleadoId);
                SessionActiva.EmpleadoId = empleado.Id;
                SessionActiva.ApyNom = empleado.Apellido +" - "+ empleado.Nombre;
                SessionActiva.Foto = empleado.Foto;

            }

            return aux;
        }

        public bool VerificarExisteUsuario()
        {
            bool aux = false;

            var usuarios = _usuarioServicio.ObtenerTodo();

            if (usuarios.Count() >= 1)
            {
                aux = true;
            }

            return aux;
        }

        public bool VerificarEmpleadoUsuario(long id)
        {
            bool aux = false;

            var usuarios = _usuarioServicio.ObtenerTodo();

            foreach (var user in usuarios)
            {
                if (user.EmpleadoId == id)
                {
                    aux = true;
                }
            }

            return aux;
        }
    }
}
