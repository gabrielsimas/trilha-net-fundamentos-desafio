
namespace DesafioFundamentos.Helpers;

public static class NumerosExtensions
{
    public static string ConvertParaLetra(this int numero)
    {
        const int tamanhoAlfabeto = 26;
        StringBuilder stringBuilder = new StringBuilder();

        while (numero >= 0)
        {
            int resto = numero % tamanhoAlfabeto;
            stringBuilder.Insert(0, (char)('A' + resto));
            numero = (numero / tamanhoAlfabeto) - 1;

            if (numero < 0)
                break;
        }

        return stringBuilder.ToString();
    }
}
