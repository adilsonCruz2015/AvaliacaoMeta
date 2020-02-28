using AvaliacaoMeta.BackEnd.Aplicacao;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.App;
using SimpleInjector;

namespace AvaliacaoMeta.BackEnd.Idc.Modulos
{
    public static class ApplicacaoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IContatoApp, ContatoApp>(Lifestyle.Scoped);
        }
    }
}
