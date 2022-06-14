using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;

namespace DistribuidoraApi.Repository
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> Get();

        Task<Endereco> Get(Guid Id);

        Task<Endereco> Create(Endereco endereco);

        Task Update(Endereco endereco);

        Task Delete(Guid Id);
    }
}
