namespace SistemaAPI.Models.DTOs
{
    public class ActividadDTO
    {
        public int Idactividad { get; set; }
        public int HoraEntrada { get; set; }
        public int HoraSalida { get; set; }
        public string Lugar { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int TipoActividadIdtipo { get; set; }
        public int GastoDiarioIdgasto { get; set; }
        public int VehiculoIdvehiculo { get; set; }

    }
}
