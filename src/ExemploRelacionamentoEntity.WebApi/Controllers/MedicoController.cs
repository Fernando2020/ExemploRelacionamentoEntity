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
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;
        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(MedicoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var medicos = await _medicoService.GetAllAsync();
            if (medicos.Any())
            {
                return Ok(medicos);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MedicoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var medico = await _medicoService.GetByIdAsync(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MedicoDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(MedicoDTO medico)
        {
            var medicoInserido = await _medicoService.AddAsync(medico);
            return CreatedAtAction(nameof(GetById), new { id = medicoInserido.Id }, medicoInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(MedicoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(MedicoDTO medico)
        {
            var medicoAtualizado = await _medicoService.UpdateAsync(medico);
            if (medicoAtualizado == null)
            {
                return NotFound();
            }
            return Ok(medicoAtualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var medicoExcliudo = await _medicoService.RemoveAsync(id);
            if (medicoExcliudo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
