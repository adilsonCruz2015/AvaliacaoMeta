using AvaliacaoMeta.BackEnd.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd
{
    public class AtualizarCmd
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Canal { get; set; }

        public string Valor { get; set; }

        public string Obs { get; set; }

        public void Aplicar(ref Contato contato)
        {
            if (!string.IsNullOrEmpty(Nome))
                contato.Nome = Nome;

            if (!string.IsNullOrEmpty(Canal))
                contato.Canal = Canal;

            if (!string.IsNullOrEmpty(Valor))
                contato.Valor = Valor;

            if (!string.IsNullOrEmpty(Obs))
                contato.Obs = Obs;
        }
    }
}
