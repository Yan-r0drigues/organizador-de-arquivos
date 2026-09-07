using OrganizadorDePastas.Models;
using System.Text.Json;

namespace OrganizadorDePastas.Services;

public class ArquivoService
{
    public static int DeletarArquivos(string caminho, int diasLimite)
    {
        var arquivos = Directory.GetFiles(caminho);
        DateTime dataLimite = DateTime.Now.AddDays(-diasLimite);

        int arquivosDeletados = 0;

        foreach (var item in arquivos)
        {
            FileInfo infoArquivo = new FileInfo(item);

            if (infoArquivo.LastWriteTime < dataLimite)
            {
                try
                {
                    File.Delete(item);
                    arquivosDeletados++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao tentar deletar o arquivo {infoArquivo.Name}: {ex.Message}");
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

    public static IEnumerable<ArquivoInfo> ListarArquivos(string caminho)
    {
        return Directory
                .GetFiles(caminho)
                .Select(caminhoArquivo =>
                {
                    var info = new FileInfo(caminhoArquivo);

                    return new ArquivoInfo
                    {
                        Nome = info.Name,
                        DataUltimaModificacao = info.LastWriteTime,
                        Caminho = info.FullName,
                        Extensao = info.Extension
                    };
                });
    }
    
    public static void OrganizarPasta(string caminhoOrigem)
    {
        if (Directory.Exists(caminhoOrigem))
        {
            var arquivos = ListarArquivos(caminhoOrigem);
            var caminhoJson = "config.json";
            string nomePastaDestino = "Outros";

            string jsonTexto = File.ReadAllText(caminhoJson);

            var regrasExtensao = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonTexto);

            foreach (var info in arquivos)
            {

                foreach (var regra in regrasExtensao)
                {
                    if (regra.Value.Contains(info.Extensao))
                    {
                        nomePastaDestino = regra.Key;
                        break;
                    }
                }

                if (string.IsNullOrEmpty(info.Extensao))
                {
                    continue;
                }

                string caminhoSubPasta = Path.Combine(caminhoOrigem, nomePastaDestino);
                Directory.CreateDirectory(caminhoSubPasta);

                string nomeArquivo = info.Nome;
                string destinoFinal = Path.Combine(caminhoSubPasta, nomeArquivo);

                File.Move(info.Caminho, destinoFinal, true);
            }
        }
    }
}
