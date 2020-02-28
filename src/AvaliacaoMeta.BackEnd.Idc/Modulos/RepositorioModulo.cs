using AvaliacaoMeta.BackEnd.Data.Persistencia.Repositorios;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio;
using SimpleInjector;

namespace AvaliacaoMeta.BackEnd.Idc.Modulos
{
    public static class RepositorioModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IContatoRep, ContatoRep>(Lifestyle.Scoped);
        }
    }
}
