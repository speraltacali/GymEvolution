using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GE.Dominio.Entity;
using GE.Dominio.Repositorio.Cliente;
using GE.Infraestructura.Repositorio.Cliente;
using GE.IServicio.Cliente;
using GE.IServicio.Cliente.DTO;
using GE.Repositorio.Base;

namespace GE.Servicio
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly IClienteRepositorio _clienteServicio;

        public ClienteServicio(ClienteRepositorio clienteRepositorio)
        {
            _clienteServicio = clienteRepositorio;
        }

        public ClienteDto Agregar(ClienteDto dto)
        {
            var cliente = new Cliente()
            {
                Apellido = dto.Apellido,
                Nombre = dto.Nombre,
                Dni = dto.Dni,
                Domicilio = dto.Domicilio,
                Telefono = dto.Telefono,
                Mail = dto.Mail,
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                GrupoSanguineo = dto.GrupoSanguineo,
                FechaDeIngreso = dto.FechaDeIngreso,
            };

            _clienteServicio.Agregar(cliente);
            _clienteServicio.Guardar();

            return dto;
        }

        public IEnumerable<ClienteDto> ObtenerTodo()
        {
            return _clienteServicio.ObtenerTodo()
                .Select(x => new ClienteDto()
                {
                    Id = x.Id,
                    Apellido = x.Apellido,
                    Nombre = x.Nombre,
                    Dni = x.Dni,
                    Domicilio = x.Domicilio,
                    Telefono = x.Telefono,
                    FechaNacimiento = x.FechaNacimiento,
                    Mail = x.Mail,
                    Sexo = x.Sexo,
                    GrupoSanguineo = x.GrupoSanguineo,
                    FechaDeIngreso = x.FechaDeIngreso,
                }).ToList();
        }

        public ClienteDto Modificar(ClienteDto clienteDto)
        {
            var cliente = _clienteServicio.ObtenerPorId(clienteDto.Id);

            cliente.Apellido = clienteDto.Apellido;
            cliente.Nombre = clienteDto.Nombre;
            cliente.Dni = clienteDto.Dni;
            cliente.Domicilio = clienteDto.Domicilio;
            cliente.Telefono = clienteDto.Telefono;
            cliente.FechaNacimiento = clienteDto.FechaNacimiento;
            cliente.Mail = clienteDto.Mail;
            cliente.Sexo = clienteDto.Sexo;
            cliente.GrupoSanguineo = clienteDto.GrupoSanguineo;
            cliente.FechaDeIngreso = clienteDto.FechaDeIngreso;

            _clienteServicio.Modificar(cliente);
            _clienteServicio.Guardar();

            return clienteDto;
        }

        public void Eliminar(long id)
        {
            _clienteServicio.Eliminar(id);
            _clienteServicio.Guardar();
        }

        public ClienteDto ObtenerTodoPorId(long id)
        {
            var cliente = _clienteServicio.ObtenerPorId(id);

            return new ClienteDto()
            {
                Id = cliente.Id,
                Apellido = cliente.Apellido,
                Nombre = cliente.Nombre,
                Dni = cliente.Dni,
                Domicilio = cliente.Domicilio,
                Telefono = cliente.Telefono,
                FechaNacimiento = cliente.FechaNacimiento,
                Mail = cliente.Mail,
                Sexo = cliente.Sexo,
                GrupoSanguineo = cliente.GrupoSanguineo,
                FechaDeIngreso = cliente.FechaDeIngreso
            };
        }
    }
}
