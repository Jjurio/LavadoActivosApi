using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IGraficoRepository
    {
        public Task<string> GraficoFrecuencia(string pResolutionType, string pAnhos);
        public Task<string> GraficoImporte(string pResolutionType, string pAnhos);

    }
}
