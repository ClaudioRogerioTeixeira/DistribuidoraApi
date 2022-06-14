using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraApi.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {

        public readonly DistribuidoraContext _context;

        public EnderecoRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<Endereco> Create(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task Delete(Guid id)
        {
            var enderecoToDelete = await _context.Enderecos.FindAsync(id);
            _context.Enderecos.Remove(enderecoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Endereco>> Get()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> Get(Guid id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task Update(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
