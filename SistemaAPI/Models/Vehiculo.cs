using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            ActividadDiaria = new HashSet<ActividadDiarium>();
        }

        public int Idvehiculo { get; set; }
        public string Placa { get; set; } = null!;
        public string Marca { get; set; } = null!;

        public virtual ICollection<ActividadDiarium> ActividadDiaria { get; set; }
    }
}
