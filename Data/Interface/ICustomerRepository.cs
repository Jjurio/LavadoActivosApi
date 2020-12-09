using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Models;

namespace LavadoActivosApi.Data.Interface
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerList>> ListarCustomer(int NroDePagina, int RegPorPag, string code, int nidPerfil);
        public Task<List<CustomerListCase>> ListarCustomerCase(int ncaso);
        public Task<List<CustomerListIOI>> ListarCustomerIOI(int ncaso);


    }
}
