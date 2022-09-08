using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioEventosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IUsuarioEventoRepository repositorio;

        public UsuarioEventosController(IUsuarioEventoRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioEvento usuarioEvento)
        {
            try
            {
                var retorno = repositorio.Inserir(usuarioEvento);
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
        /// Lista usuários/eventos da aplicação
        /// </summary>
        /// <returns>Lista de usuários/eventos</returns>
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
        /// Lista usuários/eventos da aplicação pelo Id 
        /// </summary>
        /// <param name="id">Id do usuário/evento</param>
        /// <returns>Lista de usuários/eventos</returns>
        [HttpGet("{id}")]
        public IActionResult BurcarUsuarioEventosPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new { Message = "UsuárioEvento não encontrado" });
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
