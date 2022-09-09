using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisEventos.API.Interfaces
{
    public interface ICategoriaRepository
    {
        // Classe que irá se comunicar com o Banco de Dados

        // CRUD

        // POST
        Categoria Inserir(Categoria categoria);

        // GET
        ICollection<Categoria> ListarTodos();
        Categoria BuscarPorId(int id);

        // PUT
        void Alterar(Categoria categoria);

        // DELETE
        void Excluir(Categoria categoria);

        // PUT
        void AlterarParcialmente(JsonPatchDocument patchCategoria, Categoria categoria);
    }
}
