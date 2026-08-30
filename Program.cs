namespace OrganizadorDePastas;

public class Program
{
    static void Main(string[] args)
    {
        int opcaoMenu;

        var arquivo = new Arquivo();

        do
        {
            Menu.ExibirMenu();

            opcaoMenu = int.Parse(Console.ReadLine());

            if (opcaoMenu == 1)
            {
                Console.WriteLine("Criando arquivos...");
            }
            else if (opcaoMenu == 2)
            {
                Menu.LimparTextoDaTela();

                Console.Write("\nDigite o caminho da pasta: ");
                arquivo.Caminho = Console.ReadLine();

                var arquivos = Directory.GetFiles(arquivo.Caminho);
                var quantidadeDeArquivos = Arquivo.ContarArquivosNaPasta(arquivo.Caminho);

                Menu.AlterarCorTexto(ConsoleColor.Yellow);
                Console.WriteLine("\nListando todos os arquivos do diretório...\n");
                foreach (var item in arquivos)
                {
                    FileInfo infoArquivo = new FileInfo(item);
                    Console.WriteLine($"Nome do arquivo: {infoArquivo.Name}");
                }
                Console.WriteLine($"\nTotal de arquivos na pasta: {quantidadeDeArquivos}");
                Menu.ResetarCorTexto();
                Menu.PularLinha();
            }
            else if (opcaoMenu == 3)
            {
                Console.Write("\nDigite o caminho da pasta: ");
                arquivo.Caminho = Console.ReadLine();

                if (Arquivo.ExisteCaminho(arquivo)) 
                {
                    Console.Write("Digite a quantidade de dias limite desde a última modificação: ");
                    int diasLimite = int.Parse(Console.ReadLine());

                    var quantidadeDeArquivos = Arquivo.ContarArquivosNaPasta(arquivo.Caminho);

                    Menu.AlterarCorTexto(ConsoleColor.Yellow);
                    Console.WriteLine($"\nCaminho informado: {arquivo.Caminho} - Quantidade de arquivos: {quantidadeDeArquivos}");
                    Console.Write("Tem certeza que deseja deletar os arquivos? (S/N): ");
                    string opcao = Console.ReadLine().ToLower();

                    while (opcao != "s" && opcao != "n")
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
                        Menu.LimparTextoDaTela();
                        Menu.AlterarCorTexto(ConsoleColor.Yellow);
                        Console.WriteLine("\nSaindo do programa...");
                        Menu.ResetarCorTexto();
                        return;
                    }
                }
                else
                {
                    Menu.AlterarCorTexto(ConsoleColor.Red);
                    Console.WriteLine("\nO caminho não existe.");
                    Menu.PularLinha();
                    Menu.ResetarCorTexto();
                }
            }
            else if (opcaoMenu == 0)
            {
                Menu.LimparTextoDaTela();
                Menu.AlterarCorTexto(ConsoleColor.Yellow);
                Menu.PularLinha();
                Console.WriteLine("Saindo do programa...");
                Menu.ResetarCorTexto();
                return;
            }
            else
            {
                Menu.LimparTextoDaTela();
                Menu.AlterarCorTexto(ConsoleColor.Red);
                Console.WriteLine("\nOpção inválida! Digite uma opção válida.");
                Menu.ResetarCorTexto();
                Menu.PularLinha();
            }
        } while (opcaoMenu >= 0 || opcaoMenu <= 3);
    }
}
