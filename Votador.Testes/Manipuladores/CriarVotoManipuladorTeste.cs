using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Testes.RepositoriosFalsos;

namespace Votador.Testes.Manipuladores
{
    [TestClass]
    public class CriarVotoManipuladorTeste
    {
        private readonly CriarVotoComando _votoValido = new CriarVotoComando();
        private readonly CriarVotoComando _votoInvalido = new CriarVotoComando();

        public CriarVotoManipuladorTeste()
        {
            _votoValido.FuncionarioId = "1234";
            _votoValido.RecursoId = "321";
            _votoValido.Comentario = "Gostei";
            _votoValido.Gostei = true;
            _votoValido.QuantidadeVotos = 2;
            
            _votoInvalido.FuncionarioId = "";
            _votoInvalido.RecursoId = "321";
            _votoInvalido.Comentario = "Gostei";
            _votoInvalido.Gostei = true;
            _votoInvalido.QuantidadeVotos = 2;
        }
        
        [TestMethod]
        public void Deve_criar_um_voto_caso()
        {
            var manipulador = new CriarVotoManipulador(new FalsoRepositorioVoto(), new FalsoComentarioRepositorio());
            var resultado = manipulador.Manipular(_votoValido);
            
            _votoValido.Validar();
            
            Assert.AreNotEqual(null, resultado);
            Assert.AreEqual(true, _votoValido.Valid);
            Assert.AreEqual(true, manipulador.Valid);
        }

        [TestMethod]
        public void Nao_deve_criar_voto_caso_nao_tenha_usuario()
        {
            var manipulador = new CriarVotoManipulador(new FalsoRepositorioVoto(), new FalsoComentarioRepositorio());
            var resultado = manipulador.Manipular(_votoInvalido);
            
            _votoInvalido.Validar();
            
            Assert.AreNotEqual(null, resultado);
            Assert.IsFalse(_votoInvalido.Valid);
        }
        
    }
}