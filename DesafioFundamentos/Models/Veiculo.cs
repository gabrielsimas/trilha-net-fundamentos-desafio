namespace DesafioFundamentos.Models;

public class Veiculo
{
    public Veiculo(string placa)
    {
        Placa = placa;
    }

    public string Placa { get; private set; }

    // TODO: Validação de formato de placa: AAA-9999
    public bool isPlacaValida(string placa) => true;
}
