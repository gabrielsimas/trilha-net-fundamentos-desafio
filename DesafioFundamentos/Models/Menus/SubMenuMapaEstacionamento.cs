namespace DesafioFundamentos.Models.Menus;

static class SubMenuMapaEstacionamento
{
    static Estacionamento _estacionamento;
    static MapaEstacionamento _mapaEstacionamento;

    static Estacionamento GetInstance(Estacionamento estacionamento)
    {
        if (estacionamento is Estacionamento && estacionamento != null)
            _estacionamento = estacionamento;

        return _estacionamento;
    }

    static MapaEstacionamento GetInstance(MapaEstacionamento mapaEstacionamento)
    {
        if (mapaEstacionamento is MapaEstacionamento && mapaEstacionamento != null)
            _mapaEstacionamento = mapaEstacionamento;

        return _mapaEstacionamento;
    }

    public static void ExecutarSubMenu()
    {

        int colunas;
        int linhas;

        Console.WriteLine("Digite a Coluna (Rua, Andar... etc):");
        colunas = int.Parse(Console.ReadLine());

        Console.WriteLine("Agora digite a quantidade de vagas:");
        linhas = int.Parse(Console.ReadLine());

        _mapaEstacionamento = new(linhas, colunas);        

        bool exibirMenu = true;

        while (exibirMenu)
        {
            // Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Ver Mapa completo");
            Console.WriteLine("2 - Ver Mapa por Coluna");
            Console.WriteLine("3 - Estacionar Veículo em Vaga");
            Console.WriteLine("4 - Sortear vaga para veículo");
            Console.WriteLine("5 - Vaga ocupada em tempo real");
            Console.WriteLine("6 - Valor atual da Vaga");
            Console.WriteLine("7 - Listar Veículos em Vagas");
            Console.WriteLine("8 - Checar status da Vaga");
            Console.WriteLine("9 - Retornar ao Menu Principal");

            exibirMenu = EscolhaDasOpcoes(exibirMenu);

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

    }

    private static bool EscolhaDasOpcoes(bool exibirMenu)
    {
        switch (int.Parse(Console.ReadLine()))
        {
            case 1:
                VerMapaCompleto();
                break;

            case 2:
                VerMapaPorColuna();
                break;

            case 3:
                EstacionarVeiculoEmVagaDisponivel();
                break;

            case 4:
                EstacionarVeiculoAleatoriamenteEmVaga();
                break;

            case 5:
                VagasOcupadasNoMomento();
                break;

            case 6:
                ValorAtualVaga();
                break;

            case 7:
                ListarVeiculosEmVagas();
                break;

            case 8:
                ChecarStatusDaVaga();
                break;

            case 9:
                exibirMenu = false;
                break;

            default:
                Console.WriteLine("Opção inválida");
                break;
        }

        return exibirMenu;
    }    

    // TODO: Opção Ver Mapa completo
    static void VerMapaCompleto()
    {
        Console.WriteLine(_mapaEstacionamento.ToString());
    }

    // TODO: Opção Ver Mapa por Coluna
    static void VerMapaPorColuna()
    {

    }

    // TODO: Opção Buscar Vaga
    static void BuscarVaga()
    {

    }

    // TODO: Opção Estacionar Veículo em Vaga
    static void EstacionarVeiculoEmVagaDisponivel()
    {

    }
    // TODO: Opção Sortear Veículo em Vaga
    static void EstacionarVeiculoAleatoriamenteEmVaga()
    {

    }
    // TODO: Opção Vaga ocupada em tempo real
    static void VagasOcupadasNoMomento()
    {

    }
    // TODO: Opção Valor atual da Vaga
    static void ValorAtualVaga()
    {

    }

    // TODO: Opção Listar Veículos em Vagas
    static void ListarVeiculosEmVagas()
    {

    }
    // TODO: Opção Checar status da Vaga
    static void ChecarStatusDaVaga()
    {

    }
}
