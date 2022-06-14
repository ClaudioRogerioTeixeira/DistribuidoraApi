using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DistribuidoraApi.Model;
using DistribuidoraApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DistribuidoraApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController: ControllerBase
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecosController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Endereco>> GetEnderecos()
        {
            return await _enderecoRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(Guid id)
        {
            return await _enderecoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEnderecos([FromBody] Endereco endereco)
        {
            var newEndereco = await _enderecoRepository.Create(endereco);
            return CreatedAtAction(nameof(GetEnderecos), new { id = newEndereco.Id }, newEndereco);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> Delete(Guid id)
        {
            var enderecoToDelete = await _enderecoRepository.Get(id);
            if (enderecoToDelete == null)
                return NotFound();

            await _enderecoRepository.Delete(enderecoToDelete.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> PutEnderecos(Guid id, [FromBody] Endereco endereco)
        {
            if (id != endereco.Id)
                return BadRequest();

            await _enderecoRepository.Update(endereco);

            return NoContent();
        }
    }
}
