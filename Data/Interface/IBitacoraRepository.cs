using System;
using System.Collections.Generic;
using LavadoActivosApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IBitacoraRepository
    {
        public Task<List<BitacoraList>> ListarBitacora(int idAlerta);
        public Task<Bitacora> TraerBitacora(int idAlerta);
        public Task<Alerta> InsertarBitacora(Bitacora bitacora);

    }
}
