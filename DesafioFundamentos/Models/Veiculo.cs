namespace DesafioFundamentos.Models;

public class Veiculo
{
    public Veiculo(string placa)
    {
        Placa = placa;
    }

    public Veiculo(string placa, string codigoVaga)
    {
        Placa = placa.ToUpper();
        CodigoVaga = codigoVaga.ToUpper();
        DataEntrada = DateOnly.FromDateTime(DateTime.Today);
        HoraEntrada = TimeOnly.FromDateTime(DateTime.Now);
    }

    public string Placa { get; private set; }
    public string CodigoVaga { get; private set; }
    public DateOnly DataEntrada { get; private set; } = DateOnly.FromDateTime(DateTime.Today);
    public TimeOnly HoraEntrada { get; private set; } = TimeOnly.FromDateTime(DateTime.Now);
    public TimeOnly HoraSaida {get; private set;} = TimeOnly.FromDateTime(DateTime.Now.AddHours(2));    

    public void InformarHoraSaida()
    {
        HoraSaida = TimeOnly.FromDateTime(DateTime.Now);
    }

    // TODO: Validação de formato de placa: AAA-9999
    public bool isPlacaValida(string placa) => true;

    
}
