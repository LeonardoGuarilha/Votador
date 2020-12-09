namespace Votador.Compartilhado.Comando
{
    public interface IResultadoComando
    {
        bool Sucesso { get; set; }
        string Mensagem { get; set; }
        object Dados { get; set; }
    }
}