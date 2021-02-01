using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class TipoDocumento
    {
        public int tipo_documento_id { get; set; }
        public int subfactor_id { get; set; }
        public string subfactor { get; set; }
        public string descripcion { get; set; }
        public string ponderacion { get; set; }
    }
}
