namespace DesafioFundamentos.Models;

public class MapaVeiculos
{
    public string Rua { get; private set; }
    public int Numero { get; private set; }
    public Veiculo Veiculo { get; private set; }
    public DateTime Entrada { get; private set; }
    public DateTime Saida { get; private set; }
    public int HoraManualSaida { get; set; } = 1!;

    public void CalcularHoraSaidaManual()
    {
        Saida = Entrada.AddHours(HoraManualSaida);
    }

    public int CalcularHorasDeEstacionamento()
    {
        TimeSpan diferenca = Saida - Entrada;
        return (int)diferenca.TotalHours;
    }
}
