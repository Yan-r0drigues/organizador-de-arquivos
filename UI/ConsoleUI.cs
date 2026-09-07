namespace OrganizadorDePastas.UI;

public class ConsoleUI
{
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

    public static void LimparTextoDaTela()
    {
        Console.Clear();
    }

    public static void ExibirMenu()
    {
        Console.WriteLine("=== ORGANIZADOR DE ARQUIVOS ===");
        Console.WriteLine("[1] - Listar arquivos");
        Console.WriteLine("[2] - Organizar arquivos");
        Console.WriteLine("[3] - Limpar arquivos antigos");
        Console.WriteLine("[0] - Sair");
        Console.Write("Selecione uma opção: ");
    }
}
