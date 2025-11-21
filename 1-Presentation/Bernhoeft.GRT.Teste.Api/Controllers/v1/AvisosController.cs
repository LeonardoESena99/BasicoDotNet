using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Api.Controllers.v1
{
    /// <response code="401">Não Autenticado.</response>
    /// <response code="403">Não Autorizado.</response>
    /// <response code="500">Erro Interno no Servidor.</response>
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
    public class AvisosController : RestApiController
    {
        /// <summary>
        /// Retorna Todos os Avisos Cadastrados para Tela de Edição.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Lista com Todos os Avisos.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<IEnumerable<GetAvisosResponse>>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> GetAvisos(CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisosRequest(), cancellationToken);

        /// <summary>
        /// Retornar um aviso específico com base no ID
        /// </summary>
        /// <param name="Id">Identificador do aviso</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Busca um único aviso por Id.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAvisoIdRequest))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAviso(int Id, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await Mediator.Send(new GetAvisoIdRequest(Id), cancellationToken);
                return Ok(resultado);
            }
            catch (ValidationException ex)
            {
                var mensagens = ex.Errors.Select(e => e.ErrorMessage).ToList();

                if (mensagens.Any(m => m.Contains("Nenhum aviso encontrado", StringComparison.OrdinalIgnoreCase)))
                    return NotFound(new { Erros = mensagens });

                return BadRequest(new { Erros = mensagens });
            }
        }

        /// <summary>
        /// Criar um novo aviso
        /// </summary>
        /// <param name="obj">Objeto do novo aviso a ser cadastrado</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Retorna se deu sucesso ou falha</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PostAviso([FromBody] PostAvisoRequest obj, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await Mediator.Send(obj, cancellationToken));
            }
            catch (ValidationException ex)
            {
                var mensagens = ex.Errors.Select(e => e.ErrorMessage).ToList();

                if (mensagens.Any(m => m.Contains("Nenhum aviso encontrado", StringComparison.OrdinalIgnoreCase)))
                    return NotFound(new { Erros = mensagens });

                return BadRequest(new { Erros = mensagens });
            }
        }

        /// <summary>
        /// Editar um aviso
        /// </summary>
        /// <param name="obj">Objeto de aviso a ser editado</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Retorna se deu sucesso ou falha</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutAviso([FromBody] PutAvisoRequest obj, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await Mediator.Send(obj, cancellationToken);
                return Ok(resultado);
            }
            catch (ValidationException ex)
            {
                var mensagens = ex.Errors.Select(e => e.ErrorMessage).ToList();

                if (mensagens.Any(m => m.Contains("Nenhum aviso encontrado", StringComparison.OrdinalIgnoreCase)))
                    return NotFound(new { Erros = mensagens });

                return BadRequest(new { Erros = mensagens });

            }

        }

        /// <summary>
        /// Remover um aviso
        /// </summary>
        /// <param name="obj">Remover um aviso pelo identificador</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Retorna se deu sucesso ou falha</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> AlterarStatusAviso([FromBody] AlterarStatusAvisoRequest obj, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await Mediator.Send(obj, cancellationToken));
            }
            catch (ValidationException ex)
            {
                var mensagens = ex.Errors.Select(e => e.ErrorMessage).ToList();

                if (mensagens.Any(m => m.Contains("Nenhum aviso encontrado", StringComparison.OrdinalIgnoreCase)))
                    return NotFound(new { Erros = mensagens });

                return BadRequest(new { Erros = mensagens });

            }

        }

    }
}