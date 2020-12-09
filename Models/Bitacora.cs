using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class Bitacora
    {
        public int nidUserEmi { get; set; }
        public int nidPerfilEmi { get; set; }
        public int nidUserRecep { get; set; }
        public int nidPerfilRecep { get; set; }
        public int id_action { get; set; }
        public string obs_bta { get; set; }
        public int id_resolution { get; set; }
        public int ncaso { get; set; }
        public int statusCaso { get; set; }


    }
}
