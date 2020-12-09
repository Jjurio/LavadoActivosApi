using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IOperacionRepository
    {
        public Task<string> OperacionesInusuales(string pOrigenReporte, string pAnhos);
        public Task<string> OperacionesSospechosas(string pOrigenReporte, string pAnhos);
    }
}
