using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class Login
    {
        public int nidUser { get; set; }
        public int nidPerfil { get; set; }
        public string vuser { get; set; }
        public string perfil { get; set; }
        public string vpassword { get; set; }
        public string vnombres { get; set; }
        public string vpaterno { get; set; }
        public string vmaterno { get; set; }
        public string vemail { get; set; }
        
    }
}
