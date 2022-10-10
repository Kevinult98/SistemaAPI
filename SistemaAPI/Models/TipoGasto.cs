using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class TipoGasto
    {
        public TipoGasto()
        {
            GastoDiarios = new HashSet<GastoDiario>();
        }

        public int IdtipoGasto { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<GastoDiario> GastoDiarios { get; set; }
    }
}
