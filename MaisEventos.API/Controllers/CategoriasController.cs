using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly ICategoriaRepository repositorio;

        public CategoriasController(ICategoriaRepository _repositorio)
        {
            repositorio = _repositorio;
        }
        /// <summary>
        /// Cadastra uma categoria na aplicação
        /// </summary>
        /// <param name="categoria">Dados da categoria</param>
        /// <returns>Dados da categoria cadsatrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                var retorno = repositorio.Inserir(categoria);
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
        /// Lista todas as categorias da aplicação
        /// </summary>
        /// <returns>Lista de categorias</returns>
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
        /// Lista todas as categorias da aplicação pelo Id
        /// </summary>
        /// <param name="id">Id de categorias</param>
        /// <returns>Lista de categorias</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarCategoriasPorId(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);
                if(retorno == null)
                {
                    return NotFound(new {Message = "Categoria não encontrada"});
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
        /// Altera os dados de uma categoria da aplicação
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoria">Todas as informações da categoria</param>
        /// <returns>Categoria alterada</returns>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Categoria categoria)
        {
            try
            {
                // Verificar se os Ids são válidos
                if(id != categoria.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                // Verificar se existe o Id no Banco de Dados
                var retorno = repositorio.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Categoria não encontrada" });
                }

                // Altera efetivamente a categoria
                repositorio.Alterar(categoria);

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
        /// Altera os dados parcial de uma categoria da aplicação
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <param name="categoria">Todas as informações da categoria</param>
        /// <returns>Categoria alterada</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchCategoria)
        {
            try
            {
                if (patchCategoria == null)
                {
                    return BadRequest();
                }

                // Temos que buscar o objeto
                var categoria = repositorio.BuscarPorId(id);
                if (categoria == null)
                {
                    return NotFound(new { Message = "Categoria não encontrada" });
                }

                repositorio.AlterarParcialmente(patchCategoria, categoria);

                return Ok(categoria);
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
        /// Exclui uma categoria da aplicação
        /// </summary>
        /// <param name="id">Id da categoria</param>
        /// <returns>Mensagem de exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                var busca = repositorio.BuscarPorId(id);
                if(busca == null)
                {
                    return NotFound(new { Message = "Categoria não encontrada" });
                }

                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Categoria excluída com sucesso"
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
