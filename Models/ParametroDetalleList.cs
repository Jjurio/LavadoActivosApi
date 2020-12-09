using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class ParametroDetalleList
    {
        public int parameterDetailID { get; set; }
        public int parameterID { get; set; }
        public int subParameterID { get; set; }
        public string description { get; set; }
        public int status { get; set; }

    }
}
