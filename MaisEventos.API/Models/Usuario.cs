using System;
using System.Collections.Generic;

#nullable disable

namespace MaisEventos.API.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            UsuarioEventos = new HashSet<UsuarioEvento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual ICollection<UsuarioEvento> UsuarioEventos { get; set; }
    }
}
