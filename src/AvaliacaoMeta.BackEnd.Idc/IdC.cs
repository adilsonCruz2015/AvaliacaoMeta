using AvaliacaoMeta.BackEnd.Idc.Modulos;
using SimpleInjector;

namespace AvaliacaoMeta.BackEnd.Idc
{
    public static class IdC
    {
        public static void Carregar(Container recipiente)
        {
            ApplicacaoModulo.Carregar(recipiente);
            ServicoModulo.Carregar(recipiente);
            RepositorioModulo.Carregar(recipiente);
            InfraestruturaModulo.Carregar(recipiente);
        }
    }
}
