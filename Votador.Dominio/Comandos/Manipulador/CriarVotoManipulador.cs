using Flunt.Notifications;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Resultado;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;

namespace Votador.Dominio.Comandos.Manipulador
{
    public class CriarVotoManipulador :
        Notifiable,
        IComandoManipulador<CriarVotoComando>
    {

        private readonly IVotoRepositorio _repositorio;
        private readonly IComentarioRepositorio _repositorioComentario;

        public CriarVotoManipulador(IVotoRepositorio repositorio, IComentarioRepositorio repositorioComentario)
        {
            _repositorio = repositorio;
            _repositorioComentario = repositorioComentario;
        }
        
        public IResultadoComando Manipular(CriarVotoComando comando)
        {

            var funcionarioJaVotouNaTarefa =
                _repositorio.FuncionarioJaVotouNaTarefa(comando.FuncionarioId, comando.RecursoId);

            if (funcionarioJaVotouNaTarefa != null)
            {
                return new ResultadoComando(
                    false, 
                    "Você já votou nessa tarefa", 
                    new { });
            }
            
            var recursoJaVotado = _repositorio.RecursoJaFoiVotado(comando.RecursoId);

            if (recursoJaVotado != null)
            {
                var comentarioAtualizado = new Comentario(comando.Comentario, comando.RecursoId, comando.FuncionarioId); 
                _repositorioComentario.Salvar(comentarioAtualizado);
                
                _repositorio.AtualizarVotoRecurso(comando.RecursoId);
                return new ResultadoComando(
                    true, 
                    "Voto computado com sucesso!", 
                    new { mensagem = "Obrigado por votar =)" });
                
            }
            
            var voto = new Voto(comando.FuncionarioId, comando.RecursoId, comando.Gostei);
            var comentario = new Comentario(comando.Comentario, comando.RecursoId, comando.FuncionarioId); 
            
            AddNotifications(voto.Notifications);
            

            if (!Invalid)
            {
                _repositorioComentario.Salvar(comentario);
                _repositorio.Salvar(voto);
                return new ResultadoComando(
                    true, 
                    "Voto computado com sucesso!", 
                    new { mensagem = "Obrigado por votar =)" });
            }
            
            return new ResultadoComando(
                false, 
                "Erro ao gravar o voto", 
                new { mensagem = "Ocorreu um erro ao salvar o seu voto =(" });
            
        }
    }
}