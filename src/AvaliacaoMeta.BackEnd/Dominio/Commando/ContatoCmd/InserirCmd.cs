using AvaliacaoMeta.BackEnd.Dominio.Entidade;

namespace AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd
{
    public class InserirCmd
    {
        public string Nome { get; set; }

        public string Canal { get; set; }

        public string Valor { get; set; }

        public string Obs { get; set; }

        public void Aplicar(ref Contato contato) 
        {
            contato = new Contato(Nome, Canal, Valor)
            {
                Obs = Obs
            };
        }
    }
}
