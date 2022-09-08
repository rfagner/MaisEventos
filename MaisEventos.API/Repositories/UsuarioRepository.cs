using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

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
            return ctx.Usuarios.Find(id);
        }

        public void Excluir(Usuario usuario)
        {
            throw new System.NotImplementedException();
        }

        public Usuario Inserir(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
            return usuario;
        }

        public ICollection<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
