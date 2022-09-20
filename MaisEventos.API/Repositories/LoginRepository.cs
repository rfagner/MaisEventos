using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Linq;

namespace MaisEventos.API.Repositories
{
    public class LoginRepository : ILoginRepository
    {

        private readonly MaisEventosDBContext ctx;
        public LoginRepository(MaisEventosDBContext _ctx)
        {
            ctx = _ctx;
        }

        public Usuario Logar(string email, string senha)
        {
            //return ctx.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            // Irá realizar uma pesquisa pelo email do usuário
            var usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == email);

            if(usuario != null)
            {
                // Verifica se a senha que recebe por parâmetro é a mesma senha que está no banco
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (validPassword)
                    return usuario;
            }

            return null;
        }
    }
}
