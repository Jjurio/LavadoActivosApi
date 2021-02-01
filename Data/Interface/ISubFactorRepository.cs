using LavadoActivosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface ISubFactorRepository
    {
        public Task<List<SubFactor>> listarSubFactor();
    }
}
