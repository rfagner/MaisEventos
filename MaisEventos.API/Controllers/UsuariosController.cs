using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IUsuarioRepository repositorio;

        public UsuariosController(IUsuarioRepository _repositorio)
        {
            repositorio = _repositorio;
        }

        /// <summary>
        /// Cadastra um usuário na aplicação
        /// </summary>
        /// <param name="usuario">Dados de usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                var retorno = repositorio.Inserir(usuario);
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
