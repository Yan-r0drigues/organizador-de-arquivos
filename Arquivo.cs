namespace OrganizadorDePastas;

public class Arquivo
{
    public string Nome { get; set; }
    public string Caminho { get; set; }
    public DateTime Data { get; set; }

    public static bool ExisteCaminho(Arquivo arquivo)
    {

        return Directory.Exists(arquivo.Caminho);
    }

    public static int DeletarArquivos(Arquivo arquivo)
    {
            var arquivos = Directory.GetFiles(arquivo.Caminho);
            DateTime dataLimite = DateTime.Now.AddDays(-arquivo.Data.Day);

            int arquivosDeletados = 0;

            foreach (var item in arquivos)
            {
                FileInfo infoArquivo = new FileInfo(item);

                if (infoArquivo.LastWriteTime < dataLimite)
                {
                    try
                    {
                        File.Delete(item);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Arquivo deletado: {infoArquivo.Name} (Última modificação: {infoArquivo.LastWriteTime})");
                        arquivosDeletados++;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Erro ao tentar deletar o arquivo {infoArquivo.Name}: {ex.Message}");
                        Console.ResetColor();
                    }
                }

            }

        return arquivosDeletados;
    }

    public static int ContarArquivosNaPasta(string caminho)
    {
        var quantidadeDeArquivos = Directory.GetFiles(caminho).Length;

        return quantidadeDeArquivos;
    }
}
