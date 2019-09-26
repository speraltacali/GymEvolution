using System;
using System.Collections.Generic;
using System.Text;
using GE.IServicio.Cliente.DTO;

namespace GE.IServicio.Cliente
{
    public interface IClienteServicio
    {
        ClienteDto Agregar(ClienteDto clienteDto);

        ClienteDto Modificar(ClienteDto clienteDto);

        void Eliminar(long id);

        IEnumerable<ClienteDto> ObtenerTodo();

        ClienteDto ObtenerPorId(long id);
    }
}
