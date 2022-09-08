using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using System.Collections.Generic;
using System.Linq;

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
            return ctx.Eventos.Find(id);
        }

        public void Excluir(Evento evento)
        {
            throw new System.NotImplementedException();
        }

        public Evento Inserir(Evento evento)
        {
            ctx.Eventos.Add(evento);
            ctx.SaveChanges();
            return evento;
        }

        public ICollection<Evento> ListarTodos()
        {
            return ctx.Eventos.ToList();
        }
    }
}
