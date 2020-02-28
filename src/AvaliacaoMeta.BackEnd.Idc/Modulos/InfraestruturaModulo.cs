using AvaliacaoMeta.BackEnd.Data.Persistencia.Contexto;
using AvaliacaoMeta.BackEnd.Data.Persistencia.Interfaces;
using SimpleInjector;

namespace AvaliacaoMeta.BackEnd.Idc.Modulos
{
    public static class InfraestruturaModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IConexao, Conexao>(Lifestyle.Scoped);
        }
    }
}
