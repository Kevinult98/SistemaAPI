using System;
using System.Collections.Generic;

namespace SistemaAPI.Models
{
    public partial class Bitacora
    {
        public int Idreporte { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public int? Idusuario { get; set; }

        public virtual Usuario? IdusuarioNavigation { get; set; }
    }
}
