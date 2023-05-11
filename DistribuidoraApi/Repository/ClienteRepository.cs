using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;

namespace DistribuidoraApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        public readonly DistribuidoraContext _context;

        public ClienteRepository(DistribuidoraContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            //var newCliente = _context.Clientes
            //.Include(e => e.Enderecos)
            //.Include(t => t.Telefones);

            //for (int i = 0; i <= 5; i++)
            //{
            //    cliente.Id = Guid.NewGuid();
            //    cliente.Nome = $"{cliente.Nome.Substring(0, 7)} {i}";
            //    //cliente.Enderecos = new List<endereco>();

            //    var endereco = new Endereco();
            //    endereco.Id = Guid.NewGuid();
            //    endereco.Tipo = "0";
            //    endereco.Logradouro = $"Rua {i}";
            //    endereco.Numero = $"11{i}";
            //    endereco.Complemento = $"Paralelo ao bloco {i}";
            //    endereco.Bairro = "Centro";
            //    endereco.Cidade = "Barretos";
            //    endereco.Uf = "SP";
            //    endereco.Cep = $"1578011{i}";
            //    endereco.ClienteId = cliente.Id;
            //    //cliente.Enderecos = new List<Endereco>();
            //    //cliente.Enderecos.Add(endereco);

            //    var telefone = new Telefone();
            //    telefone.Id = Guid.NewGuid();
            //    telefone.Tipo = "0";
            //    telefone.Ddd = "17";
            //    telefone.Numero = $"Rua {i}";
            //    telefone.Observacao = $"Testando Inclusão {i}";
            //    telefone.ClienteId = cliente.Id;
            //    //cliente.Telefones = new List<Telefone>();
            //    //cliente.Telefones.Add(telefone);

            //    //_context.Clientes.AddRange(cliente);
            //    //_context.Enderecos.AddRange(endereco);
            //    //_context.Telefones.AddRange(telefone);
            //    //_context.SaveChanges();

            //    _context.Clientes.Add(cliente);
            //    _context.Enderecos.Add(endereco);
            //    _context.Telefones.Add(telefone);
            //    await _context.SaveChangesAsync();
            //}

            _context.Clientes.Add(cliente);
            //_context.Enderecos.Add(endereco);
            //_context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();

            return cliente;
        }

        /*
        public async Task<IEnumerable<Cliente>> Get()
        {        
            return await _context.Clientes.ToListAsync();
        }
         
         */

        public async Task<IEnumerable<Cliente>> Get()
        {
            var clientes = _context.Clientes
               .Include(e => e.Enderecos)
               .Include(t => t.Telefones);

            var id = new Guid("7D4A2B49-7598-4062-B0CD-43EDA228F3E1");
            var clienteAtual = await _context.Clientes.FindAsync(id);


            return await clientes.ToListAsync();

        }

        public async Task<Cliente> Get(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Update(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var clienteToDelete = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
