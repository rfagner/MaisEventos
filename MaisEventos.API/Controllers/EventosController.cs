using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace MaisEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IEventoRepository repositorio;

        public EventosController(IEventoRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        /// <summary>
        /// Cadastra eventos na aplicação
        /// </summary>
        /// <param name="evento">Dados de eventos</param>
        /// <returns>Dados de eventos cadastrados</returns>
        [HttpPost]
        public IActionResult Cadastrar(Evento evento)
        {
            try
            {
                var retorno = repositorio.Inserir(evento);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Lista todos os eventos da aplicação
        /// </summary>
        /// <returns>LIsta de eventos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var retorno = repositorio.ListarTodos();
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Lista todos os eventos da aplicação pelo Id
        /// </summary>
        /// <param name="id">Id de eventos</param>
        /// <returns>LIsta de eventos</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarEventosPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new { Message = "Evento não encontrado" });
                }

                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Altera os dados de um evento da aplicação
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="evento">Todas as informações do evento</param>
        /// <returns>Evento alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Evento evento)
        {
            try
            {
                // Verificar se os Ids são válidos
                if (id != evento.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se existe o Id no Banco de Dados
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Evento não encontrado" });
                }

                // Altera efetivamente a categoria
                repositorio.Alterar(evento);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Altera os dados parcial de um evento da aplicação
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="evento">Todas as informações do evento</param>
        /// <returns>Evento alterado</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchEvento)
        {
            try
            {
                if (patchEvento == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var evento = repositorio.BuscarPorId(id);
                if (evento == null)
                {
                    return NotFound(new { Message = "Evento não encontrado" });
                }

                repositorio.AlterarParcialmente(patchEvento, evento);

                return Ok(evento);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }

        /// <summary>
        /// Exclui um evento da aplicação
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var busca = repositorio.BuscarPorId(id);
                if(busca == null)
                {
                    return NotFound(new { Message = "Evento não encontrado" });
                }

                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Evento excluído com sucesso"
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na conexão",
                    erro = ex.Message,
                });
            }
        }
    }
}
