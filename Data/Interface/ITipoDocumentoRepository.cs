using LavadoActivosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface ITipoDocumentoRepository
    {
        public Task<List<TipoDocumento>> listarTipoDocumento();
        public Task actualizarTipoDocumento(TipoDocumento tipoDocumento);
    }
}
