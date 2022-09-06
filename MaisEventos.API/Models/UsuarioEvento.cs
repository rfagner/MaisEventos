using System;
using System.Collections.Generic;

#nullable disable

namespace MaisEventos.API.Models
{
    public partial class UsuarioEvento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int EventoId { get; set; }

        public virtual Evento Evento { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
