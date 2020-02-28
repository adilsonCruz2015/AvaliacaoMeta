using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Servico;
using AvaliacaoMeta.BackEnd.Dominio.Servicos;
using SimpleInjector;

namespace AvaliacaoMeta.BackEnd.Idc.Modulos
{
    public static class ServicoModulo
    {
        public static void Carregar(Container recipiente)
        {
            recipiente.Register<IContatoServ, ContatoServ>(Lifestyle.Scoped);
        }
    }
}
