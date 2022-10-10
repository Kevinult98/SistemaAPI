using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoUsuario { get; set; }
        public string Descripcion { get; set; } = null!;
        public bool? Estado { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
