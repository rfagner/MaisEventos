using MaisEventos.API.Data;
using MaisEventos.API.Interfaces;
using MaisEventos.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
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
            ctx.Entry(evento).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchEvento, Evento evento)
        {
            patchEvento.ApplyTo(evento);
            ctx.Entry(evento).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public Evento BuscarPorId(int id)
        {
            return ctx.Eventos.Find(id);
        }

        public void Excluir(Evento evento)
        {
            ctx.Eventos.Remove(evento);
            ctx.SaveChanges();
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
