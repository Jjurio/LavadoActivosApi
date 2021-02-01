using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class SubFactor
    {
        public int subfactor_id { get; set; }
        public int factor_id { get; set; }
        public string factor { get; set; }
        public int tipo_ponderacion_id { get; set; }
        public string tipo_ponderacion { get; set; }
        public string url { get; set; }
        public string descripcion { get; set; }
    }
}
