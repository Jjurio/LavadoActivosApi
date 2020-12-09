﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LavadoActivosApi.Models;

namespace LavadoActivosApi.Data.Interface
{
    public interface IParametroRepository
    {
        public Task<List<ParametroDetalleList>> ListarParametroDetalle(int parameterID);

    }
}
