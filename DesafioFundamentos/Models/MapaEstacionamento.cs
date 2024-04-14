namespace DesafioFundamentos.Models;

class MapaEstacionamento
{
    private readonly IDictionary<string, string> _vagas;
    private readonly int _colunas;
    private readonly int _linhas;
    public MapaEstacionamento(int linhas, int colunas)
    {
        _linhas = linhas;
        _colunas = colunas;

        _vagas = Gerar();
    }

    private IDictionary<string, string> Gerar()
    {
        IDictionary<string, string> vagas = new Dictionary<string, string>();

        for (int coluna = 0; coluna < _colunas; coluna++)
        {
            int vaga = 0;
            string linhaLetra = coluna.ConvertParaLetra();
            for (int linha = 0; linha < _linhas; linha++)
            {
                vaga++;
                string key = $"{linhaLetra}{vaga}";
                vagas.Add(key, null);
            }
        }

        return vagas;
    }

    public IDictionary<string, string> GetVagas() => _vagas;


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        for (int coluna = 0; coluna < _colunas; coluna++)
        {
            int inc = 0;
            for (int linha = 0; linha < _linhas; linha++)
            {
                inc++;
                string vaga = $"{Convert.ToChar('A' + coluna)}{inc}";                

                if (!string.IsNullOrEmpty(_vagas[vaga]))
                {
                    sb.Append($"[ {vaga} - {_vagas[vaga]} ]");
                }
                else
                {
                    sb.Append($"[ {vaga} - Disponível ]"); // Empty spot with spot code
                }
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public void CadastrarVeiculoNaVagaPorCodigoEPlaca(string codigoVaga, string placaVeiculo)
    {
        string vaga = codigoVaga;
        string plate = placaVeiculo;

        if (!IsVaga(vaga))
        {
            Console.WriteLine($"A Vaga {vaga} não existe nesse Estacionamento");
            return;
        }

        if (IsVagaOcupada(codigoVaga))
        {
            Console.WriteLine($"A Vaga {vaga} já está ocupada pelo veiculo {_vagas[codigoVaga]}");
            return;
        }
        _vagas[codigoVaga] = plate;
    }

    public bool IsVagaOcupada(string vaga)
        => !string.IsNullOrEmpty(_vagas[vaga]);

    public string BuscarPlacaVeiculoPorVaga(string vaga)
    {
        if (!string.IsNullOrEmpty(_vagas[vaga]))
            return _vagas[vaga];

        return "Disponível";
    }

    public string BuscarLocalizacaoDoVeiculoPelaPlaca(string placa)
        => _vagas.FirstOrDefault(x => x.Value.Equals(placa)).Key;

    public bool IsVaga(string vaga) => _vagas.ContainsKey(vaga);
    public void RemoverVeiculo(string placa)
    {
        string vaga = BuscarLocalizacaoDoVeiculoPelaPlaca(placa);
        _vagas[vaga] = null;
    }

    public void RegerarMapa()
    {
        Gerar();
    }
}
