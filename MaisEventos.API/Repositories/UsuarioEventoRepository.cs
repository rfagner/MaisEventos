using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaisEventos.API.Repositories
{
    public class UsuarioEventoRepository : IUsuarioEventoRepository
    {
        // Injeção de Dependência
        MaisEventosDBContext ctx;
        public UsuarioEventoRepository(MaisEventosDBContext _ctx)
        {
            ctx = _ctx;
        }

        public void Alterar(UsuarioEvento usuarioEvento)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioEvento BuscarPorId(int id)
        {
            return ctx.UsuarioEventos.Find(id);
        }

        public void Excluir(UsuarioEvento usuarioEvento)
        {
            throw new System.NotImplementedException();
        }

        public UsuarioEvento Inserir(UsuarioEvento usuarioEvento)
        {
            ctx.UsuarioEventos.Add(usuarioEvento);
            ctx.SaveChanges();
            return usuarioEvento;
        }

        public ICollection<UsuarioEvento> ListarTodos()
        {
            return ctx.UsuarioEventos.ToList();
        }
    }
}
