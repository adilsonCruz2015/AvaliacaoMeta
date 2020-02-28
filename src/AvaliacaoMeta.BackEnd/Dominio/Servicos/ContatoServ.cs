using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd;
using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd.Validacao;
using AvaliacaoMeta.BackEnd.Dominio.Entidade;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Repositorio;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.Servico;
using AvaliacaoMeta.BackEnd.Dominio.Servicos.Comum;

namespace AvaliacaoMeta.BackEnd.Dominio.Servicos
{
    public class ContatoServ : BaseService, IContatoServ
    {
        public ContatoServ(INotificador notificador,
                           IContatoRep rep)
            : base(notificador)
        {
            _rep = rep;
            _notificador = notificador;
        }

        private readonly IContatoRep _rep;
        private readonly INotificador _notificador;

        public int Atualizar(AtualizarCmd comando)
        {
            int resultado = -1;

            if(ExecutarValidacao(new AtualizarValidacao(), comando))
            {
                Contato contato = _rep.Get(comando.Id);

                if(!object.Equals(contato, null))
                {
                    comando.Aplicar(ref contato);
                    resultado = _rep.Update(contato);

                    if (resultado < 0)
                        Notificar("Não foi possível atualizar o contato");
                }
                else
                {
                    Notificar("Registro não encontrado!");
                }
            }

            return resultado;
        }

        public Contato[] Filtrar(FiltrarCmd comando)
        {
            Contato[] contatos = null;

            if (ExecutarValidacao(new FiltrarValidacao(), comando))
                contatos = _rep.Filtrar(comando);

            return contatos;
        }

        public int Inserir(InserirCmd comando)
        {
            int resultado = -1;

            if (ExecutarValidacao(new InserirValidacao(), comando))
            {
                Contato contato = null;
                comando.Aplicar(ref contato);

                resultado = _rep.Insert(contato);
                if (resultado < 0)
                    Notificar("Não foi possível inserir o contato");
            }

            return resultado;
        }

        public Contato Obter(string id)
        {
            Contato contato = _rep.Get(id);

            if (object.Equals(contato, null))
                Notificar("Registro não encontrado!");

            return contato;
        }

        public int Delete(string id)
        {
            int resultado = -1;

            if (!string.IsNullOrEmpty(id))
            {
                resultado = _rep.Delete(id);
                if (resultado < 0)
                    Notificar("Não foi possível excluír o contato");
            }
            else
            {
                Notificar("Id inválido");
            }

            return resultado;
        }
    }
}
