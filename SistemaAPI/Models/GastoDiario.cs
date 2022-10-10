using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class GastoDiario
    {
        public GastoDiario()
        {
            ActividadDiaria = new HashSet<ActividadDiarium>();
        }

        public int Idgasto { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Foto { get; set; } = null!;
        public int TipoGastoIdtipoGasto { get; set; }
        public float Total { get; set; }

        public virtual TipoGasto TipoGastoIdtipoGastoNavigation { get; set; } = null!;
        public virtual ICollection<ActividadDiarium> ActividadDiaria { get; set; }
    }
}
