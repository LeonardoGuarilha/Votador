using Flunt.Notifications;
using Votador.Compartilhado.Comando;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Resultado;
using Votador.Dominio.Entidades;
using Votador.Dominio.Repositorios;

namespace Votador.Dominio.Comandos.Manipulador
{
    public class CriarRecursoManipulador :
        Notifiable,
        IComandoManipulador<CriarRecursoComando>
    {

        private readonly IRecursoRepositorio _repositorio;

        public CriarRecursoManipulador(IRecursoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        
        public IResultadoComando Manipular(CriarRecursoComando comando)
        {
            var recurso = new Recurso(comando.Titulo, comando.Descricao);
            
            AddNotifications(recurso.Notifications);

            if (!Invalid)
            {
                _repositorio.Salvar(recurso);
                
                return new ResultadoComando(
                    true, 
                    "Recurso cadastrado com sucesso!", 
                    new { titulo = recurso.Titulo, descricao = recurso.Descricao });
            }
            else
            {
                return new ResultadoComando(
                    false, 
                    "Erro ao cadastrar recurso", 
                    new { notificacoes = recurso.Notifications });
            }
                
        }
    }
}