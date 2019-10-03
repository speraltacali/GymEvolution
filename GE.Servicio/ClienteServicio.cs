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

        public ClienteServicio()
        {
            _clienteServicio = new ClienteRepositorio();
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
                FechaNacimiento = dto.FechaNacimiento,
                Sexo = dto.Sexo,
                Foto = dto.Foto,
                GrupoSanguineo = dto.GrupoSanguineo,
                FechaDeIngreso = dto.FechaDeIngreso,
                FotoLink = dto.FotoLink
            };

            _clienteServicio.Agregar(cliente);
            _clienteServicio.Guardar();

            dto.Id = cliente.Id;

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
                    Sexo = x.Sexo,
                    GrupoSanguineo = x.GrupoSanguineo,
                    FechaDeIngreso = x.FechaDeIngreso,
                    FotoLink = x.FotoLink
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
            cliente.Sexo = clienteDto.Sexo;
            cliente.GrupoSanguineo = clienteDto.GrupoSanguineo;
            cliente.FechaDeIngreso = clienteDto.FechaDeIngreso;

            if(clienteDto.FotoLink != null)
            { 
            cliente.FotoLink = clienteDto.FotoLink;
            }

            _clienteServicio.Modificar(cliente);
            _clienteServicio.Guardar();

            return clienteDto;
        }

        public void Eliminar(long id)
        {
            _clienteServicio.Eliminar(id);
            _clienteServicio.Guardar();
        }

        public ClienteDto ObtenerPorId(long id)
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
                Sexo = cliente.Sexo,
                GrupoSanguineo = cliente.GrupoSanguineo,
                FechaDeIngreso = cliente.FechaDeIngreso,
                FotoLink = cliente.FotoLink
            };
        }
    }
}
