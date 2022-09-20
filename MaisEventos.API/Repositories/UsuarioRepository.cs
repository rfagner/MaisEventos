using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
            // Converte a senha original em algoritmo
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchUsuario, Usuario usuario)
        {
            patchUsuario.ApplyTo(usuario);
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public void Excluir(Usuario usuario)
        {
            ctx.Usuarios.Remove(usuario);
            ctx.SaveChanges();
        }

        public Usuario Inserir(Usuario usuario)
        {
            // Converte a senha original em algoritmo
            usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

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
