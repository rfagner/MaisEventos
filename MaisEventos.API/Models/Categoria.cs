using System;
using System.Collections.Generic;

#nullable disable

namespace MaisEventos.API.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Eventos = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string NomeCategoria { get; set; }

        public virtual ICollection<Evento> Eventos { get; set; }
    }
}
