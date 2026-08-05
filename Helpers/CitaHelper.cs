namespace Final_Web_Carlos.Helpers
{
    public static class CitaHelper
    {
        public static string CalcularEstado(DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            var ahora = DateTime.Now;

            if (ahora < fechaHoraInicio)
                return "Vigente";

            if (ahora >= fechaHoraInicio && ahora <= fechaHoraFin)
                return "En proceso";

            return "Finalizado";
        }

        public static string CalcularTiempoRestante(DateTime fechaHoraInicio)
        {
            var diferencia = fechaHoraInicio - DateTime.Now;

            if (diferencia.TotalSeconds <= 0)
                return "Finalizada";

            int dias = diferencia.Days;
            int horas = diferencia.Hours;
            int minutos = diferencia.Minutes;

            if (dias > 0)
                return $"{dias} días {horas} horas";

            if (horas > 0)
                return $"{horas} horas {minutos} minutos";

            return $"{minutos} minutos";
        }
    }
}