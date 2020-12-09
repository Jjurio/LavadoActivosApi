using System;
using System.Collections.Generic;
using LavadoActivosApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IBitacoraRepository
    {
        public Task<string> InsertarBitacora(Bitacora bitacora);
        public Task<List<BitacoraList>> ListarBitacora(int ncaso);

    }
}
