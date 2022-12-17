using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Bitacoras = new HashSet<Bitacora>();
            Equipos = new HashSet<Equipo>();
            ActividadDiariaIdactividads = new HashSet<ActividadDiarium>();
        }

        public int Idusuario { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string? NumeroTelefono { get; set; }
        public string Email { get; set; } = null!;
        public string Clave { get; set; } = null!;
        public string? Direccion { get; set; }
        public string? CodigoRecuperacion { get; set; }
        public bool? Estado { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string? NombreUsuario { get; set; }

        public virtual TipoUsuario? IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Bitacora> Bitacoras { get; set; }
        public virtual ICollection<Equipo> Equipos { get; set; }

        public virtual ICollection<ActividadDiarium> ActividadDiariaIdactividads { get; set; }
    }
}
