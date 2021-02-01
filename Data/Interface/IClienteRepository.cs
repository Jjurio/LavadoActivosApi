using LavadoActivosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IClienteRepository
    {
        public Task<List<Cliente>> listarClientes(string descripcion, string numero_documento);
        public Task insertarImportCliente(Cliente cliente);
        public Task<int> insertarCliente();
    }
}
