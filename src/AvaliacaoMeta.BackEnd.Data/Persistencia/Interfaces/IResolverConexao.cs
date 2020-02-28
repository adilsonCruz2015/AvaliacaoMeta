using AvaliacaoMeta.BackEnd.Dominio.ObjetoDeValor;

namespace AvaliacaoMeta.BackEnd.Data.Persistencia.Interfaces
{
    public interface IResolverConexao
    {
        string ObterReferencia(string nome);

        string ObterConexao(Banco banco);
    }
}
