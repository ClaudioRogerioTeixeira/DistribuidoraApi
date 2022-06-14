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
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefoneRepository _telefoneRepository;
        public TelefonesController(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Telefone>> GetTelefones()
        {
            return await _telefoneRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Telefone>> GetTelefone(Guid id)
        {
            return await _telefoneRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Telefone>> PostTelefone([FromBody] Telefone telefone)
        {
            var newTelefone = await _telefoneRepository.Create(telefone);
            return CreatedAtAction(nameof(GetTelefones), new { id = newTelefone.Id }, newTelefone);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Telefone>> Delete(Guid id)
        {
            var telefoneToDelete = await _telefoneRepository.Get(id);
            if (telefoneToDelete == null)
                return NotFound();

            await _telefoneRepository.Delete(telefoneToDelete.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Telefone>> PutTelefone(Guid id, [FromBody] Telefone telefone)
        {
            if (id != telefone.Id)
                return BadRequest();

            await _telefoneRepository.Update(telefone);

            return NoContent();
        }
    }
}
