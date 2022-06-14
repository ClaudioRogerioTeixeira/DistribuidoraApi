using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraApi.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {

        public readonly DistribuidoraContext _context;

        public TelefoneRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<Telefone> Create(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();
            return telefone;
        }

        public async Task Delete(Guid id)
        {
            var telefoneToDelete = await _context.Telefones.FindAsync(id);
            _context.Telefones.Remove(telefoneToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Telefone>> Get()
        {
            return await _context.Telefones.ToListAsync();
        }

        public async Task<Telefone> Get(Guid id)
        {
            return await _context.Telefones.FindAsync(id);
        }

        public async Task Update(Telefone telefone)
        {
            _context.Entry(telefone).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }        

    }
}
