namespace OrganizadorDePastas.Models;

public class ResultadoLimpeza
{
    public int ArquivosEncontrados { get; set; }
    public int ArquivosDeletados { get; set; }
    public List<string> Erros { get; set; } = [];
}
