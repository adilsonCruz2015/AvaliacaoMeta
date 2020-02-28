namespace AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio.Comum
{
    public interface IRepositorioBaseLeitura<TEntidade>
        where TEntidade : class
    {
        TEntidade[] Get();

        TEntidade Get(string id);
    }
}
