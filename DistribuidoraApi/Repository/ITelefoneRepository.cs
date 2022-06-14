using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;

namespace DistribuidoraApi.Repository
{
    public interface ITelefoneRepository
    {
        Task<IEnumerable<Telefone>> Get();

        Task<Telefone> Get(Guid Id);

        Task<Telefone> Create(Telefone telefone);

        Task Update(Telefone telefone);

        Task Delete(Guid Id);
    }
}
