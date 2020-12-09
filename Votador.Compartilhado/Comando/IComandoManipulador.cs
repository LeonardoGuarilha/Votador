namespace Votador.Compartilhado.Comando
{
    public interface IComandoManipulador<T> where T : IComando
    {
        IResultadoComando Manipular(T comando);
    }
}