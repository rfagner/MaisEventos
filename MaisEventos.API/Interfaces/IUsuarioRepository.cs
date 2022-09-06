using MaisEventos.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MaisEventos.API.Interfaces
{
    public interface IUsuarioRepository
    {
        // Classe que irá se comunicar com o Banco de Dados

        // CRUD

        // POST
        Usuario Inserir(Usuario usuario);

        // GET
        ICollection<Usuario> ListarTodos();
        Usuario BuscarPorId(int id);

        // PUT
        void Alterar(Usuario usuario);

        // DELETE
        void Excluir(Usuario usuario);
    }
}
