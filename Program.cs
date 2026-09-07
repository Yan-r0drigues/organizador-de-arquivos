using OrganizadorDePastas.Models;
using OrganizadorDePastas.Services;
using OrganizadorDePastas.UI;

namespace OrganizadorDePastas;

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            ConsoleUI.ExibirMenu();

            if (!int.TryParse(Console.ReadLine(), out int opcaoMenu))
            {
                Console.WriteLine("Digite uma opção válida.");
                continue;
            }

            if (opcaoMenu == 1)
            {
                ConsoleUI.LimparTextoDaTela();

                Console.Write("\nDigite o caminho da pasta: ");
                string caminho = Console.ReadLine();

                var arquivos = ArquivoService.ListarArquivos(caminho);
                var quantidadeDeArquivos = ArquivoService.ContarArquivosNaPasta(caminho);

                ConsoleUI.AlterarCorTexto(ConsoleColor.Yellow);
                Console.WriteLine("\nListando todos os arquivos do diretório...\n");

                foreach (var arquivo in arquivos)
                {
                    Console.WriteLine($"Nome do arquivo: {arquivo.Nome} - Data da última modificação: {arquivo.DataUltimaModificacao}");
                }

                Console.WriteLine($"\nTotal de arquivos na pasta: {quantidadeDeArquivos}");
                ConsoleUI.ResetarCorTexto();
                ConsoleUI.PularLinha();
            }
            else if (opcaoMenu == 2)
            {
                Console.Write("\nDigite o caminho da pasta: ");
                string caminho = Console.ReadLine();

                ArquivoService.OrganizarPasta(caminho);
            }
            else if (opcaoMenu == 3)
            {
                Console.Write("\nDigite o caminho da pasta: ");
                string caminho = Console.ReadLine();

                if (Directory.Exists(caminho)) 
                {
                    Console.Write("Digite a quantidade de dias limite desde a última modificação: ");
                    int diasLimite = int.Parse(Console.ReadLine());

                    var quantidadeDeArquivos = ArquivoService.ContarArquivosNaPasta(caminho);

                    ConsoleUI.AlterarCorTexto(ConsoleColor.Yellow);
                    Console.WriteLine($"\nCaminho informado: {caminho} - Quantidade de arquivos: {quantidadeDeArquivos}");
                    Console.Write("Tem certeza que deseja deletar os arquivos? (S/N): ");
                    string escolha = Console.ReadLine().ToLower();

                    while (escolha != "s" && escolha != "n")
                    {
                        ConsoleUI.AlterarCorTexto(ConsoleColor.Red);
                        Console.WriteLine("Erro! Digite um valor válido.");
                        ConsoleUI.ResetarCorTexto();

                        ConsoleUI.PularLinha();

                        ConsoleUI.AlterarCorTexto(ConsoleColor.Yellow);
                        Console.Write("Tem certeza que deseja deletar os arquivos? (S/N): ");
                        escolha = Console.ReadLine().ToLower();
                    }

                    ConsoleUI.ResetarCorTexto();

                    if (escolha == "s")
                    {
                        var arquivosDeletados = ArquivoService.DeletarArquivos(caminho, diasLimite);

                        ConsoleUI.AlterarCorTexto(ConsoleColor.Green);
                        Console.WriteLine($"\nLimpeza concluída com sucesso! Total de arquivos deletados: {arquivosDeletados}");
                        ConsoleUI.ResetarCorTexto();
                    }
                    else if (escolha == "n")
                    {
                        ConsoleUI.LimparTextoDaTela();
                        ConsoleUI.AlterarCorTexto(ConsoleColor.Yellow);
                        Console.WriteLine("\nSaindo do programa...");
                        ConsoleUI.ResetarCorTexto();
                        return;
                    }
                }
                else
                {
                    ConsoleUI.AlterarCorTexto(ConsoleColor.Red);
                    Console.WriteLine("\nO caminho não existe.");
                    ConsoleUI.PularLinha();
                    ConsoleUI.ResetarCorTexto();
                }
            }
            else if (opcaoMenu == 0)
            {
                ConsoleUI.LimparTextoDaTela();
                ConsoleUI.AlterarCorTexto(ConsoleColor.Yellow);
                ConsoleUI.PularLinha();
                Console.WriteLine("Saindo do programa...");
                ConsoleUI.ResetarCorTexto();
                break;
            }
            else
            {
                ConsoleUI.LimparTextoDaTela();
                ConsoleUI.AlterarCorTexto(ConsoleColor.Red);
                Console.WriteLine("\nOpção inválida! Digite uma opção válida.");
                ConsoleUI.ResetarCorTexto();
                ConsoleUI.PularLinha();
            }
        }
    }
}
