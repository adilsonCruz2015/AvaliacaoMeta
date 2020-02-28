using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd;
using AvaliacaoMeta.BackEnd.Dominio.Entidade;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio.Comum;

namespace AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio
{
    public interface IContatoRep : IRepositorioBaseEscrita<Contato>,
                                   IRepositorioBaseLeitura<Contato>
    {
        Contato[] Filtrar(FiltrarCmd comando);
    }
}
