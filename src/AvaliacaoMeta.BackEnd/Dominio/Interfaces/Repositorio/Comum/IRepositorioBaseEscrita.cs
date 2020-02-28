namespace AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorioBaseEscrita<TEntidade>
        where TEntidade : class
    {
        int Insert(TEntidade obj);

        int Update(TEntidade obj);

        int Delete(string id);
    }
}
