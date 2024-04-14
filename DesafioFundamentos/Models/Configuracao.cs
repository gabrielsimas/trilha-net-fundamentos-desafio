namespace DesafioFundamentos.Models;

public class Configuracao
{
    public Configuracao(decimal precoInicial, decimal precoPorHora)
    {
        PrecoInicial = precoInicial;
        PrecoPorHora = precoPorHora;
    }

    public Configuracao(int linhas, int colunas)
    {
        Linhas = linhas;
        Colunas = colunas;
    }

    public decimal PrecoInicial { get; private set; } = 0!;
    public decimal PrecoPorHora { get; private set; } = 0!;
    public int Linhas { get; private set; } = 1!;
    public int Colunas { get; private set; } = 1!;


}
