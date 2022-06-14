using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraApi.Model
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public String Tipo { get; set; }
        public string CnpjCpf { get; set; }
        public string RgIe { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc_fundacao { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
    }
}
