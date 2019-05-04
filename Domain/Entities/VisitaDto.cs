using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanosApi.Domain.Entities
{
    public class VisitaDto
    {
        public string id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Consultor { get; set; }
        public string Data { get; set; }
        public string TipoVisita { get; set; }
        public string TipoCliente { get; set; }
        public string StatusCliente { get; set; }
    }
}
