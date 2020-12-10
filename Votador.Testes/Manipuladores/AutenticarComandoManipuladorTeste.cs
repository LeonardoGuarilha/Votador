using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Testes.RepositoriosFalsos;

namespace Votador.Testes.Manipuladores
{
    [TestClass]
    public class AutenticarComandoManipuladorTeste
    {
        private readonly AutenticarFuncionarioComando _autenticacaoValida = new AutenticarFuncionarioComando();
        private readonly AutenticarFuncionarioComando _autenticacaoInvalida = new AutenticarFuncionarioComando();

        public AutenticarComandoManipuladorTeste()
        {
            _autenticacaoValida.Email = "email@email.com";
            _autenticacaoValida.Senha = "123456";
            
            _autenticacaoInvalida.Email = "";
            _autenticacaoInvalida.Senha = "123456";
        }
        
        [TestMethod]
        public void Deve_autenticar_funcionario_com_informacoes_corretas()
        {
            var manipulador = new AutenticarComandoManipulador(new FalsoRepositorioFuncionario());
            var resultado = manipulador.Manipular(_autenticacaoValida);
            
            _autenticacaoValida.Validar();
            
            Assert.AreNotEqual(null, resultado);
            Assert.AreEqual(true, manipulador.Valid);
            Assert.AreEqual(true, _autenticacaoValida.Valid);
        }

        [TestMethod]
        public void Nao_deve_autorizar_usuario_caso_nao_tenha_email()
        {
            var manipulador = new AutenticarComandoManipulador(new FalsoRepositorioFuncionario());
            var resultado = manipulador.Manipular(_autenticacaoInvalida);
            
            _autenticacaoInvalida.Validar();
            
            Assert.IsFalse(_autenticacaoInvalida.Valid);
            Assert.AreNotEqual(null, resultado);
        }
        
    }
}