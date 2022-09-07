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
    }
}
