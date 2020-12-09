using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class BitacoraList
    {
        public int nidUserEmi { get; set; }
        public string emisor { get; set; }
        public int nidUserRecep { get; set; }
        public string receptor { get; set; }
        public string rol { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string desc_action { get; set; }
        public string obs_bta { get; set; }
        public int id_resolution { get; set; }
        public string desc_resolution { get; set; }
        public int ncaso { get; set; }
        public int userJob { get; set; }
        public int perfilJob { get; set; }
        public int fAsig { get; set; }
        public int userAnt { get; set; }
        public string nombreAnt { get; set; }
        public int perfilAnt { get; set; }
        public int resolAnt { get; set; }
        public int userAna1 { get; set; }
        public string nombreAna1 { get; set; }
        public int idBitacora { get; set; }
        public int idBitacoraResp { get; set; }
        public int statusCase { get; set; }

    }
}
