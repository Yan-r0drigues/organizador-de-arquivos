namespace OrganizadorDePastas.Models;

public class ArquivoInfo
{
    public string Nome { get; set; } = string.Empty;
    public string Caminho { get; set; } = string.Empty;
    public DateTime DataUltimaModificacao { get; set; }
    public string Extensao { get; set; } = string.Empty;
}
