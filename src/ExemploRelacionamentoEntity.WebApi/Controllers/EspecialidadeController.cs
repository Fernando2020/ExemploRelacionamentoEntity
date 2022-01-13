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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeService _especialidadeService;
        public EspecialidadeController(IEspecialidadeService especialidadeService)
        {
            _especialidadeService = especialidadeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EspecialidadeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var especialidades = await _especialidadeService.GetAllAsync();
            if (especialidades.Any())
            {
                return Ok(especialidades);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EspecialidadeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            var especialidade = await _especialidadeService.GetByIdAsync(id);
            if (especialidade == null)
            {
                return NotFound();
            }
            return Ok(especialidade);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EspecialidadeDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(EspecialidadeDTO especialidade)
        {
            var especialidadeInserido = await _especialidadeService.AddAsync(especialidade);
            return CreatedAtAction(nameof(GetById), new { id = especialidadeInserido.Id }, especialidadeInserido);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EspecialidadeDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(EspecialidadeDTO especialidade)
        {
            var especialidadeAtualizado = await _especialidadeService.UpdateAsync(especialidade);
            if (especialidadeAtualizado == null)
            {
                return NotFound();
            }
            return Ok(especialidadeAtualizado);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var especialidadeExcliudo = await _especialidadeService.RemoveAsync(id);
            if (especialidadeExcliudo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
