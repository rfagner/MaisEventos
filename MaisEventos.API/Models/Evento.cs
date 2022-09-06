using System;
using System.Collections.Generic;

#nullable disable

namespace MaisEventos.API.Models
{
    public partial class Evento
    {
        public Evento()
        {
            UsuarioEventos = new HashSet<UsuarioEvento>();
        }

        public int Id { get; set; }
        public DateTime? DataHora { get; set; }
        public bool? Ativo { get; set; }
        public decimal? Preco { get; set; }
        public int? CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<UsuarioEvento> UsuarioEventos { get; set; }
    }
}
