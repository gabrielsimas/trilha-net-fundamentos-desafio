using DesafioFundamentos.Helpers;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {

        private List<Veiculo> _veiculos = new List<Veiculo>();
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public decimal PrecoInicial { get; private set; } = 0!;
        public decimal PrecoPorHora { get; private set; } = 0!;
        public IReadOnlyList<Veiculo> Veiculos { get => _veiculos.ToList(); }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            _veiculos.Add(veiculo);
        }

        public void RemoverVeiculo(Veiculo veiculo)
        {
            _veiculos.RemoveAll(x => x.Placa.Equals(veiculo.Placa, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool isVeiculoExiste(Veiculo veiculo)
        => _veiculos.Any(x => x.Placa.Equals(veiculo.Placa, StringComparison.InvariantCultureIgnoreCase));

        public decimal CalcularValorEstacionamento(int horas) => PrecoInicial + PrecoPorHora * horas;

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
    }
}
