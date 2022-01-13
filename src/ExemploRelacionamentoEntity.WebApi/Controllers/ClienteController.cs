using ExemploRelacionamentoEntity.Service.DTO;
using ExemploRelacionamentoEntity.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploRelacionamentoEntity.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            if (clientes.Any())
            {
                return Ok(clientes);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(ClienteDTO cliente)
        {
            var clienteInserido = await _clienteService.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = clienteInserido.Id }, clienteInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ClienteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(ClienteDTO cliente)
        {
            var clienteAtualizado = await _clienteService.UpdateAsync(cliente);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }
            return Ok(clienteAtualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var clienteExcliudo = await _clienteService.RemoveAsync(id);
            if (clienteExcliudo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
