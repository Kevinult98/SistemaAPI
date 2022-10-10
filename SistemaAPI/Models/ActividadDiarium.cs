using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class ActividadDiarium
    {
        public ActividadDiarium()
        {
            UsuarioidUsuarios = new HashSet<Usuario>();
        }

        public int Idactividad { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public string Lugar { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int TipoActividadIdtipo { get; set; }
        public int GastoDiarioIdgasto { get; set; }
        public int VehiculoIdvehiculo { get; set; }

        public virtual GastoDiario GastoDiarioIdgastoNavigation { get; set; } = null!;
        public virtual TipoActividad TipoActividadIdtipoNavigation { get; set; } = null!;
        public virtual Vehiculo VehiculoIdvehiculoNavigation { get; set; } = null!;

        public virtual ICollection<Usuario> UsuarioidUsuarios { get; set; }
    }
}
