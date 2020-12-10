using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votador.Dominio.Comandos.Entrada;
using Votador.Dominio.Comandos.Manipulador;
using Votador.Testes.RepositoriosFalsos;

namespace Votador.Testes.Manipuladores
{
    [TestClass]
    public class CriarRecursoManipuladorTeste
    {
        
        private readonly CriarRecursoComando _recursoVaido = new CriarRecursoComando();
        private readonly CriarRecursoComando _recursoInvalido = new CriarRecursoComando();

        public CriarRecursoManipuladorTeste()
        {
            _recursoVaido.Titulo = "Novo recurso";
            _recursoVaido.Descricao = "Criação de novo recurso";
            
            _recursoInvalido.Titulo = "";
            _recursoInvalido.Descricao = "Criação de novo recurso";
        }
        
        [TestMethod]
        public void Deve_cadastrar_um_novo_recurso()
        {
            var manipulador = new CriarRecursoManipulador(new FalsoRepositorioRecurso());
            var resultado = manipulador.Manipular(_recursoVaido);
            
            _recursoVaido.Validar();
            
            Assert.AreNotEqual(null, resultado);
            Assert.AreEqual(true, manipulador.Valid);
            Assert.AreEqual(true, _recursoVaido.Valid);
        }

        [TestMethod]
        public void Nao_deve_criar_recurso_csao_nao_tenha_titulo()
        {
            var manipulador = new CriarRecursoManipulador(new FalsoRepositorioRecurso());
            var resultado = manipulador.Manipular(_recursoInvalido);
            
            _recursoInvalido.Validar();
            
            Assert.IsFalse(_recursoInvalido.Valid);
            Assert.AreNotEqual(null, resultado);
        }
    }
        
}
