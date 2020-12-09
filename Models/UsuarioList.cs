using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class UsuarioList
    {
        public int nidUser { get;set;}
        public string nombre { get; set; }
        public int nidPerfil { get; set; }
        public string vnombrePerfil { get; set; }
        public int nestado { get; set; }

    }
}
