using Microsoft.AspNetCore.Mvc;
using MinhaAPIWeb.Models;
using MinhaAPIWeb.Repositorio;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClienteAPIWeb.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Cliente>> GetBooks()
        {
            return await _clienteRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetBooks(int id)
        {
            return await _clienteRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostBooks([FromBody] Cliente cliente )
        {
            var newBook = await _clienteRepository.Create(cliente);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var ClienteToDelete = await _clienteRepository.Get(id);

            if (ClienteToDelete != null)
                return NotFound();
                await _clienteRepository.Delete(ClienteToDelete.Id);
           
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult<Cliente>> PutBooks(int id, [FromBody] Cliente cliente)
        {
            if (id == cliente.Id)
                return BadRequest();
                await _clienteRepository.Update(cliente);   
            
            return NoContent();
        }


    }
}
