using MaisEventos.API.Models;
using System.Collections.Generic;

namespace MaisEventos.API.Interfaces
{
    public interface IEventoRepository
    {
        // Classe que irá se comunicar com o Banco de Dados

        // CRUD

        // POST
        Evento Inserir(Evento evento);

        // GET
        ICollection<Evento> ListarTodos();
        Evento BuscarPorId(int id);

        // PUT
        void Alterar(Evento evento);

        // DELETE
        void Excluir(Evento evento);
    }
}
