namespace OrganizadorDePastas;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ORGANIZADOR DE ARQUIVOS ===");

        var arquivo = new Arquivo();

        Console.Write("Digite o caminho da pasta: ");
        arquivo.Caminho = Console.ReadLine();

        Console.Write("Digite a quantidade de dias limite desde a última modificação: ");

        int diasLimite = 0;

        Menu.PreencherCampo(diasLimite);

        var quantidadeDeArquivos = Arquivo.ContarArquivosNaPasta(arquivo.Caminho);

        Menu.AlterarCorTexto(ConsoleColor.Yellow);
        Console.WriteLine($"\nCaminho informado: {arquivo.Caminho} - Quantidade de arquivos: {quantidadeDeArquivos}");
        Console.Write("Tem certeza que deseja deletar os arquivos? (S/N): ");
        string opcao = Console.ReadLine().ToLower();

        while(opcao != "s" && opcao != "n")
        {
            Menu.AlterarCorTexto(ConsoleColor.Red);
            Console.WriteLine("Erro! Digite um valor válido.");
            Menu.ResetarCorTexto();

            Menu.PularLinha();

            Menu.AlterarCorTexto(ConsoleColor.Yellow);
            Console.Write("Tem certeza que deseja deletar os arquivos? (S/N): ");
            opcao = Console.ReadLine().ToLower();
        }

        Menu.ResetarCorTexto();

        if (opcao == "s")
        {
            var arquivosDeletados = Arquivo.DeletarArquivos(arquivo);

            Menu.AlterarCorTexto(ConsoleColor.Green);
            Console.WriteLine($"\nLimpeza concluída com sucesso! Total de arquivos deletados: {arquivosDeletados}");
            Menu.ResetarCorTexto();
        }
        else if (opcao == "n")
        {
            Menu.AlterarCorTexto(ConsoleColor.Yellow);
            Console.WriteLine("\nSaindo do programa...");
            Menu.ResetarCorTexto();
        }
    }
}
