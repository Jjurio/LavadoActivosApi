using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class CondicionCliente
    {
        public int condicion_cliente_id { get; set; }
        public string descripcion { get; set; }
        public int tipo_ponderacion_id { get; set; }
        public string tipo_ponderacion { get; set; }
        public string ponderacion { get; set; }
    }
}
