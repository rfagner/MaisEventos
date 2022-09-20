using MaisEventos.API.Models;

namespace MaisEventos.API.Interfaces
{
    public interface ILoginRepository
    {
        Usuario Logar(string email, string senha);
    }
}
