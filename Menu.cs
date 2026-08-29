namespace OrganizadorDePastas;

public class Menu
{
    public static int ValidarCampo(int valor)
    {
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nEntrada inválida! Por favor, digite um número inteiro maior ou igual a zero:");
            Console.ResetColor();
        }

        return valor;
    }

    public static int PreencherCampo(int valor)
    {
        valor = ValidarCampo(valor);
        return valor;
    }

    public static void PularLinha()
    {
        Console.WriteLine();
    }

    public static void AlterarCorTexto(ConsoleColor cor)
    {
        Console.ForegroundColor = cor;
    }

    public static void ResetarCorTexto()
    {
        Console.ResetColor();
    }
}
