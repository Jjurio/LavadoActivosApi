using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class BitacoraList
    {
        public int idBitacora { get; set; }
        public int idAlerta { get; set; }
        public int nidUserEmi { get; set; }
        public string emisor { get; set; }
        public string perfilEmisor { get; set; }
        public int nidUserRecep { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public int id_action { get; set; }
        public string desc_action { get; set; }
        public string obs_bta { get; set; }
        public int id_resolution { get; set; }
        public string desc_resolution { get; set; }

    }
}
