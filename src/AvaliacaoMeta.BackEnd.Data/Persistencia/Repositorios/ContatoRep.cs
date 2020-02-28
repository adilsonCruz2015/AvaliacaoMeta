using AvaliacaoMeta.BackEnd.Data.Persistencia.Interfaces;
using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd;
using AvaliacaoMeta.BackEnd.Dominio.Entidade;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio;
using AvaliacaoMeta.BackEnd.Dominio.ObjetoDeValor;
using Dapper;
using System.Data;
using System.Linq;
using System.Text;

namespace AvaliacaoMeta.BackEnd.Data.Persistencia.Repositorios
{
    public class ContatoRep : IContatoRep
    {
        public ContatoRep(IConexao conexao)
        {
            _conexao = conexao;
            _conexao.InformarBanco(Banco.AvaliacaoTailorit);
        }

        private readonly IConexao _conexao;

        public Contato[] Filtrar(FiltrarCmd comando)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"SELECT 
                                Id,
                                Nome,
                                Canal,
                                Valor,
                                Obs                        
                          FROM { nameof(Contato)} ");
            sql.Append(" ORDER BY Nome OFFSET @Offset ROWS FETCH NEXT @Next ROWS ONLY ");

            return _conexao.Sessao.Query<Contato>(sql.ToString(),
                    new
                    {
                        Next = comando.Size,
                        Offset = (comando.Page - 1) * comando.Size
                    }, _conexao.Transicao).ToArray();
        }

        public int Insert(Contato obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"
                         INSERT INTO { nameof(Contato) } (Nome, Canal, Valor, Obs)
                                VALUES(@Nome, @Canal, @Valor, @Obs)");

            var parametros = new DynamicParameters(new { obj.Id});
            parametros.Add("@Nome",obj.Nome, DbType.String, size: 100);
            parametros.Add("@Canal", obj.Canal, DbType.String, size: 255);
            parametros.Add("@Valor", obj.Valor, DbType.String, size: 255);
            parametros.Add("@Obs", obj.Obs, DbType.String, size: 255);

            return _conexao.Sessao.Execute(sql.ToString(), parametros, _conexao.Transicao);
        }

        public int Update(Contato obj)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"
                         UPDATE  { nameof(Contato) } 
                         SET Nome = @Nome, 
                             Canal = @Canal, 
                             Valor = @Valor, 
                             Obs = @Obs  
                         WHERE Id = @Id");

            var parametros = new DynamicParameters(new { obj.Id });
            parametros.Add("@Nome", obj.Nome, DbType.String, size: 100);
            parametros.Add("@Canal", obj.Canal, DbType.String, size: 255);
            parametros.Add("@Valor", obj.Valor, DbType.String, size: 255);
            parametros.Add("@Obs", obj.Obs, DbType.String, size: 255);

            return _conexao.Sessao.Execute(sql.ToString(), parametros, _conexao.Transicao);
        }

        public Contato[] Get()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"SELECT 
                                Id,
                                Nome,
                                Canal,
                                Valor,
                                Obs                        
                          FROM { nameof(Contato)} ");

            return _conexao.Sessao.Query<Contato>(
                          sql.ToString(),
                          new { },
                          _conexao.Transicao).ToArray();
        }

        public Contato Get(string id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"SELECT 
                                Id,
                                Nome,
                                Canal,
                                Valor,
                                Obs                        
                           FROM { nameof(Contato)} WHERE Id = @Id");

            return _conexao.Sessao.Query<Contato>(
                          sql.ToString(),
                          new { id },
                          _conexao.Transicao).FirstOrDefault();
        }

        public int Delete(string Id)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append($@"DELETE 
                          FROM { nameof(Contato)} WHERE Id = @Id ");

            var parametros = new DynamicParameters(new { Id });

            return _conexao.Sessao.Execute(sql.ToString(), parametros, _conexao.Transicao);
        }
    }
}
