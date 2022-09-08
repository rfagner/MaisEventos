using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
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
    }
}
