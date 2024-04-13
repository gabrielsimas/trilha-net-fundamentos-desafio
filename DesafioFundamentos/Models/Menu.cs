namespace DesafioFundamentos.Models;

static class Menu
{
    private static Estacionamento estacionamento;
    public static void ExecutarMenu()
    {
        decimal precoInicial;
        decimal precoPorHora;

        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                            "Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());

        estacionamento = new(precoInicial, precoPorHora);

        bool exibirMenu = true;

        while (exibirMenu)
        {
            // Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("5 - Encerrar");

            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    AdicionarVeiculo();
                    break;

                case 2:
                    RemoverVeiculo();
                    break;

                case 3:
                    ListarVeiculos();
                    break;

                case 4:
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }

    static void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        Veiculo veiculo = new Veiculo(Console.ReadLine());
        estacionamento.AdicionarVeiculo(veiculo);
    }

    static void ListarVeiculos()
    {
        estacionamento.ListarVeiculos();
    }

    static void RemoverVeiculo()
    {
        decimal valorTotal;

        Console.WriteLine("Digite a placa do veículo para remover:");
        Veiculo veiculo = new(Console.ReadLine());

        if (!estacionamento.isVeiculoExiste(veiculo))
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            Console.ReadLine();
        }

        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
        int horas = int.Parse(Console.ReadLine());

        valorTotal = estacionamento.CalcularValorEstacionamento(horas);

        estacionamento.RemoverVeiculo(veiculo);

        Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");
    }
}
