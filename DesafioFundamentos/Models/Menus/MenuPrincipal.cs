namespace DesafioFundamentos.Models.Menus;

static class MenuPrincipal
{
    private static Estacionamento estacionamento;
    private static Configuracao configuracao;
    public static void ExecutarMenu()
    {
        decimal precoInicial;
        decimal precoPorHora;
        int colunas;
        int linhas;


        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                        "Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Digite a quantidade de Colunas (Rua, Andar... etc):");
        colunas = int.Parse(Console.ReadLine());

        Console.WriteLine("Agora digite a quantidade de vagas:");
        linhas = int.Parse(Console.ReadLine());

        estacionamento = new(precoInicial, precoPorHora, colunas, linhas);

        bool exibirMenu = true;

        while (exibirMenu)
        {
            // Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Liberar vaga");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            exibirMenu = EscolhaDasOpcoes(exibirMenu);

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
    }

    private static bool EscolhaDasOpcoes(bool exibirMenu)
    {
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

            // case 4:
            //     SubMenuMapaEstacionamento.ExecutarSubMenu();
            //     break;

            case 4:
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        return exibirMenu;
    }

    static void AdicionarVeiculo()
    {
        Console.WriteLine("Digite a placa do veículo para estacionar:");
        string placa = Console.ReadLine();
        
        Console.WriteLine("Informe a Vaga baseado no Mapa:");
        Console.WriteLine(estacionamento.MostrarMapaDeOcupacao());
        string vaga = Console.ReadLine();

        Veiculo veiculo = new Veiculo(placa,vaga);
        estacionamento.AdicionarVeiculo(veiculo);
        Console.WriteLine(estacionamento.MostrarMapaDeOcupacao());
        Console.WriteLine($"Veiculo {veiculo.Placa} estacionou na vaga {veiculo.CodigoVaga}");
    }

    static void ListarVeiculos()
    {
        Console.WriteLine(estacionamento.MostrarMapaDeOcupacao());
    }

    static void RemoverVeiculo()
    {
        decimal valorTotal;

        Console.WriteLine(estacionamento.MostrarMapaDeOcupacao());

        Console.WriteLine("Digite a placa do veículo para remover:");
        string placa = Console.ReadLine();        

        if (!estacionamento.isVeiculoExiste(placa))
        {
            Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("A quantidade de horas que o veículo permaneceu estacionado. Tecle 0 para hora atual:");
        int horas = int.Parse(Console.ReadLine());

        Veiculo veiculo = estacionamento.BuscaVeiculoPelaPlaca(placa);

        if(horas == 0)
            veiculo.InformarHoraSaida();
        
        valorTotal = estacionamento.CalcularValorEstacionamento(veiculo);

        estacionamento.RemoverVeiculo(veiculo);        

        Console.WriteLine($"O veículo {veiculo.Placa} foi removido e o preço total foi de: R$ {valorTotal}");

        Console.WriteLine($"Vaga {veiculo.CodigoVaga} liberada!");
        Console.WriteLine(estacionamento.MostrarMapaDeOcupacao());
    }
}
