using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class Login
    {
        public string respuesta { get; set; }
        public int nidUser { get; set; }
        public string vdescripcion { get; set; }
        public string vuser { get; set; }
        public string vnombres { get; set; }
        public string vpaterno { get; set; }
        public string vmaterno { get; set; }
        public int vsexo { get; set; }
        public string vemail { get; set; }
        public string profdescripcion { get; set; }
        public int nidPerfil { get; set; }
    }
}
