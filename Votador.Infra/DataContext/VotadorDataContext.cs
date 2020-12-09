using System;
using System.Data;
using Npgsql;
using Votador.Compartilhado;

namespace Votador.Infra.DataContext
{
    public class VotadorDataContext : IDisposable
    {

        public NpgsqlConnection Conexao { get; set; }

        public VotadorDataContext()
        {
            Conexao = new NpgsqlConnection(Configuracoes.ConnectionString);
            Conexao.Open();
        }
        
        public void Dispose()
        {
            if (Conexao.State != ConnectionState.Closed)
                Conexao.Close();
        }
    }
}