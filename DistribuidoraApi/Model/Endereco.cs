using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DistribuidoraApi.Model
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public Guid ClienteId { get; set; }

        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}
