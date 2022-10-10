using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class TipoActividad
    {
        public TipoActividad()
        {
            ActividadDiaria = new HashSet<ActividadDiarium>();
        }

        public int Idtipo { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<ActividadDiarium> ActividadDiaria { get; set; }
    }
}
