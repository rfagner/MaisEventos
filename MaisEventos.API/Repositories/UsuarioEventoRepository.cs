using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
            ctx.Entry(usuarioEvento).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchUsuarioEvento, UsuarioEvento usuarioEvento)
        {
            patchUsuarioEvento.ApplyTo(usuarioEvento);
            ctx.Entry(usuarioEvento).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public UsuarioEvento BuscarPorId(int id)
        {
            return ctx.UsuarioEventos.Find(id);
        }

        public void Excluir(UsuarioEvento usuarioEvento)
        {
            ctx.UsuarioEventos.Remove(usuarioEvento);
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
