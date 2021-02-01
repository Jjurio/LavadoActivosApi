using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LavadoActivosApi.Models
{
    public class Cliente
    {
        public int cliente_id { get; set; }
        public int empresa_id { get; set; }
        public string descripcion { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string nacionalidad { get; set; }
        public string provincia { get; set; }
        public string condicion_cliente { get; set; }
        public string tipo_cliente { get; set; }
        public string condicion_juridica { get; set; }
        public string estado_contribuyente { get; set; }
        public string condicion_tributaria { get; set; }
        public string condicion_laboral { get; set; }
        public string rango_etario { get; set; }
        public string antiguedad_cliente { get; set; }
        public string antiguedad_juridica { get; set; }
        public string tipo_operacion { get; set; }
        public string beneficiario_final { get; set; }
        public string ejecutante { get; set; }
        public string canal { get; set; }
    }
}
