using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd;
using AvaliacaoMeta.BackEnd.Dominio.Entidade;

namespace AvaliacaoMeta.BackEnd.Dominio.Interfaces.App
{
    public interface IContatoApp
    {
        int Inserir(InserirCmd comando);

        int Atualizar(AtualizarCmd comando);

        Contato Obter(string id);

        Contato[] Filtrar(FiltrarCmd comando);

        int Delete(string id);
    }
}
