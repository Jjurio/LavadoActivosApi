using LavadoActivosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Data.Interface
{
    public interface IAlertaRepository
    {
        public Task<List<Alerta>> ListarAlerta(int usuario_id);
        public Task<Alerta> TraerAlerta(int customerID);
    }
}
