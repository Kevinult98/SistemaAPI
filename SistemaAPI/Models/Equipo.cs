using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class Equipo
    {
        public int Idequipo { get; set; }
        public string Marca { get; set; } = null!;
        public string NumeroSerie { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public int UsuarioidUsuario { get; set; }

        public virtual Usuario UsuarioidUsuarioNavigation { get; set; } = null!;
    }
}
