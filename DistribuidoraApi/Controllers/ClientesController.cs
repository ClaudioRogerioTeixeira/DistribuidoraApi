using DistribuidoraApi.Model;
using DistribuidoraApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DistribuidoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _clienteRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(Guid id) 
        {
            return await _clienteRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> PostClientes([FromBody] Cliente cliente) 
        {
            var newCliente =  await _clienteRepository.Create(cliente);
            return CreatedAtAction(nameof(GetClientes), new { id = newCliente.Id }, newCliente);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(Guid id) 
        {
            var clienteToDelete = await _clienteRepository.Get(id);
            if (clienteToDelete == null)
                return NotFound();

            await _clienteRepository.Delete(clienteToDelete.Id);                
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Cliente>> PutClientes(Guid id, [FromBody] Cliente cliente ) 
        {
            if (id != cliente.Id)
                return BadRequest();

            await _clienteRepository.Update(cliente);

            return NoContent();            
        }

    }
}
