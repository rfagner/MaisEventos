using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Collections.Generic;

namespace MaisEventos.API.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        // Injeção de Dependência
        MaisEventosDBContext ctx;
        public EventoRepository(MaisEventosDBContext _ctx)
        {
            ctx = _ctx;
        }

        public void Alterar(Evento evento)
        {
            throw new System.NotImplementedException();
        }

        public Evento BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Evento evento)
        {
            throw new System.NotImplementedException();
        }

        public Evento Inserir(Evento evento)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Evento> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
