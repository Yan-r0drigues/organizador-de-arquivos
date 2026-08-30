namespace OrganizadorDePastas;

public class Menu
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
        Console.WriteLine("[1] - Criar arquivos");
        Console.WriteLine("[2] - Listar arquivos");
        Console.WriteLine("[3] - Deletar arquivos");
        Console.WriteLine("[0] - Sair");
        Console.Write("Selecione uma opção: ");
    }
}
