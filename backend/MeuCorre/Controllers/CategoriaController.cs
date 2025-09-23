using MediatR;
using MeuCorre.Application.UseCases.Categorias.Commands;
using MeuCorre.Application.UseCases.Categorias.Dtos;
using MeuCorre.Application.UseCases.Categorias.Queries;
using MeuCorre.Application.UseCases.Usuarios.Commands;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MeuCorre.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CategoriaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria uma nova categoria para o usuário
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Retorna uma nova categoria criada</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CategoriaDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CriarCategoria([FromBody] CriarCategoriaCommad command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return Conflict(mensagem);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarCategoria([FromBody] AtualizarCategoriaCommand command)
        {
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return BadRequest(mensagem);
            }

        }

        [HttpDelete]
        public async Task<IActionResult> DeletarCategoria([FromBody] DeletarCategoriaCommad command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpPatch("{id}/ativar")]
        public async Task<IActionResult> AtivarCategoria([FromRoute] Guid id)
        {
            var command = new AtivarCategoriaCommand { CategoriaId = id };
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpPatch("{id}/inativar")]
        public async Task<IActionResult> inativarCategoria([FromRoute] Guid id)
        {
            var command = new AtivarCategoriaCommand { CategoriaId = id };
            var (mensagem, sucesso) = await _mediator.Send(command);
            if (sucesso)
            {
                return Ok(mensagem);
            }
            else
            {
                return BadRequest(mensagem);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObterCategorias([FromQuery] ListarTodasCategoriasQuery query)
        {
            var categorias = await _mediator.Send(query);
            return Ok(categorias);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> ObterCategoriaPorId([FromRoute] Guid id)
        {
            var query = new ObterCategoriaQuery{ CategoriaId = id };
            var categoria = await _mediator.Send(query);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(categoria);
        }
    }

}


