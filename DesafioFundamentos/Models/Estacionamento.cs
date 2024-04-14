namespace DesafioFundamentos.Models
{
    class Estacionamento
    {
        private readonly decimal _precoInicial;
        private readonly decimal _precoPorHora;
        private int _horaSaidaManual = 0;
        private List<Veiculo> _veiculos = new List<Veiculo>();
        private readonly MapaEstacionamento _mapaEstacionamento;
        public Estacionamento(decimal precoInicial, decimal precoPorHora, int colunas, int linhas)
        {
            _precoInicial = precoInicial;
            _precoPorHora = precoPorHora;
            _mapaEstacionamento = new(linhas, colunas);
        }

        public IReadOnlyList<Veiculo> Veiculos { get => _veiculos.ToList(); }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);

            if (!string.IsNullOrEmpty(veiculo.CodigoVaga.ToUpper()))
                _mapaEstacionamento.CadastrarVeiculoNaVagaPorCodigoEPlaca(veiculo.CodigoVaga.ToUpper(), veiculo.Placa);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculos.RemoveAll(x => x.Placa.Equals(veiculo.Placa, StringComparison.InvariantCultureIgnoreCase));
            _mapaEstacionamento.RemoverVeiculo(veiculo.Placa);
        }

        public bool isVeiculoExiste(Veiculo veiculo)
        => _veiculos.Any(x => x.Placa.Equals(veiculo.Placa, StringComparison.InvariantCultureIgnoreCase));

        public bool isVeiculoExiste(string placa)
        => _veiculos.Any(x => x.Placa.Equals(placa, StringComparison.InvariantCultureIgnoreCase));

        public Veiculo BuscaVeiculoPelaPlaca(string placa)
            => _veiculos.Where(x => x.Placa.Equals(placa, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();

        public decimal CalcularValorEstacionamento(Veiculo veiculo)
        {
            decimal total = 0;
            if (_horaSaidaManual == 0)
            {
                TimeSpan horas = veiculo.HoraSaida - veiculo.HoraEntrada;
                total = _precoInicial + _precoPorHora * (int)horas.TotalHours;
            }
            else
            {
                total = _precoInicial + _precoPorHora * _horaSaidaManual;
            }

            return total;
        }

        public void ListarVeiculos()
        {
            if (!_veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Os veículos estacionados são:");

            foreach (Veiculo veiculo in Veiculos)
            {
                Console.WriteLine(veiculo.Placa);
            }
        }

        public string MostrarMapaDeOcupacao() => _mapaEstacionamento.ToString();

        public void RegerarMapa()
        {
            _mapaEstacionamento.RegerarMapa();
        }
    }
}
