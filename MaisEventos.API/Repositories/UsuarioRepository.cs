using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Collections.Generic;

namespace MaisEventos.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        // Injeção de Dependência
        MaisEventosDBContext ctx;
        public UsuarioRepository(MaisEventosDBContext _ctx)
        {
            ctx = _ctx;
        }

        public void Alterar(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Inserir(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Usuario> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
