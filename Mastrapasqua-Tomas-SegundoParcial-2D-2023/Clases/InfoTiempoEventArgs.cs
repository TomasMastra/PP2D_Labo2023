public class InfoTiempoEventArgs : EventArgs
{
    public int Hora { get; }
    public int Minuto { get; }
    public int Segundo { get; }

    public InfoTiempoEventArgs(int hora, int minuto, int segundo)
    {
        Hora = hora;
        Minuto = minuto;
        Segundo = segundo;
    }
}