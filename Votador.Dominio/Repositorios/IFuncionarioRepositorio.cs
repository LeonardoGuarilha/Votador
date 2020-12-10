using System.Collections.Generic;
using Votador.Dominio.Consultas;
using Votador.Dominio.Entidades;

namespace Votador.Dominio.Repositorios
{
    public interface IFuncionarioRepositorio
    {
        void Salvar(Funcionario funcionario);
        RetornarEmailConsultaResultado EmailExiste(string email);
        Funcionario UsuarioExiste(string email);
        IEnumerable<RetornarFuncionarioConsulta> RetornarUsuarios();
    }
}