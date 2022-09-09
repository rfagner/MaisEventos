using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisEventos.API.Interfaces
{
    public interface IUsuarioEventoRepository
    {
        // Classe que irá se comunicar com o Banco de Dados

        // CRUD

        // POST
        UsuarioEvento Inserir(UsuarioEvento usuarioEvento);

        // GET
        ICollection<UsuarioEvento> ListarTodos();
        UsuarioEvento BuscarPorId(int id);

        // PUT
        void Alterar(UsuarioEvento usuarioEvento);

        // DELETE
        void Excluir(UsuarioEvento usuarioEvento);

        // PUT
        void AlterarParcialmente(JsonPatchDocument patchUsuarioEvento, UsuarioEvento usuarioEvento);
    }
}
