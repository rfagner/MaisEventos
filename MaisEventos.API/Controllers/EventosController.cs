using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
