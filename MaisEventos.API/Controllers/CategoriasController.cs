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
    }
}
