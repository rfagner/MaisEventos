using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
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
            throw new System.NotImplementedException();
        }

        public Categoria BuscarPorId(int id)
        {
            return ctx.Categorias.Find(id);
        }

        public void Excluir(Categoria categoria)
        {
            throw new System.NotImplementedException();
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
