using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <summary>
        /// Altera os dados de UsuarioEventos da aplicação
        /// </summary>
        /// <param name="id">Id de UsuarioEvento</param>
        /// <param name="usuarioEvento">Todas as informações de UsuarioEvento</param>
        /// <returns>UsuarioEvento alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, UsuarioEvento usuarioEvento)
        {
            try
            {
                // Verificar se os Ids são válidos
                if (id != usuarioEvento.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se existe o Id no Banco de Dados
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "UsuarioEvento não encontrado" });
                }

                // Altera efetivamente a categoria
                repositorio.Alterar(usuarioEvento);

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
        /// Altera os dados parcial de UsuarioEventos da aplicação
        /// </summary>
        /// <param name="id">Id de UsuarioEvento</param>
        /// <param name="usuarioEvento">Todas as informações de UsuarioEvento</param>
        /// <returns>UsuarioEvento alterado</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchUsuarioEvento)
        {
            try
            {
                if (patchUsuarioEvento == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var usuarioEvento = repositorio.BuscarPorId(id);
                if (usuarioEvento == null)
                {
                    return NotFound(new { Message = "UsuarioEvento não encontrado" });
                }

                repositorio.AlterarParcialmente(patchUsuarioEvento, usuarioEvento);

                return Ok(usuarioEvento);
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
        /// Exclui um UsuarioEvento da aplicação
        /// </summary>
        /// <param name="id">Id de UsuarioEvento</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var busca = repositorio.BuscarPorId(id);
                if(busca == null)
                {
                    return NotFound(new { Message = "UsuarioEvento não encontrado" });
                }

                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "UsuarioEvento excluído com sucesso"
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
