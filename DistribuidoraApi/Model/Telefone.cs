using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DistribuidoraApi.Model
{
    public class Telefone
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        public string Observacao { get; set; }
        public Guid ClienteId { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}
