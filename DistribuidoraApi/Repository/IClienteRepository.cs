using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;

namespace DistribuidoraApi.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> Create(Cliente cliente);

        Task<IEnumerable<Cliente>> Get();

        Task<Cliente> Get(Guid Id);

        Task Update(Cliente cliente);

        Task Delete(Guid Id);

    }
}
