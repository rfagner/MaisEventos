using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MaisEventos.API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        // Injeção de Dependência
        MaisEventosDBContext ctx;
        public CategoriaRepository(MaisEventosDBContext _ctx)
        {
            ctx = _ctx;
        }

        public void Alterar(Categoria categoria)
        {
            ctx.Entry(categoria).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchCategoria, Categoria categoria)
        {
            patchCategoria.ApplyTo(categoria);
            ctx.Entry(categoria).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Categoria BuscarPorId(int id)
        {
            return ctx.Categorias.Find(id);
        }

        public void Excluir(Categoria categoria)
        {
            ctx.Categorias.Remove(categoria);
            ctx.SaveChanges();
        }

        public Categoria Inserir(Categoria categoria)
        {
            ctx.Categorias.Add(categoria);
            ctx.SaveChanges();
            return categoria;
        }

        public ICollection<Categoria> ListarTodos()
        {
            return ctx.Categorias.ToList();
        }
    }
}
