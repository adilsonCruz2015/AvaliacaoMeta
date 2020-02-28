using AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd;
using AvaliacaoMeta.BackEnd.Dominio.Entidade;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces;
using AvaliacaoMeta.BackEnd.Dominio.Interfaces.App;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AvaliacaoMeta.BackEnd.Api.Controllers
{
    [RoutePrefix("Contato")]
    [Description("Gerenciar Contatos")]
    public class ContatoController : MainController
    {
        public ContatoController(INotificador notificador,
                                 IContatoApp app)
            : base(notificador)
        {
            _app = app;
        }

        private readonly IContatoApp _app;



        [HttpGet, Route("{idContato}")]
        [Display(Name = "Filtrar")]
        public async Task<HttpResponseMessage> Get([FromUri] string idContato)
        {
            Contato contato = null;

            if (!string.IsNullOrEmpty(idContato))
                contato = _app.Obter(idContato);

            return CustomResponse(contato);
        }

        [HttpPut, Route("{idContato}")]
        [Display(Name = "Atualizar")]
        public async Task<HttpResponseMessage> Put([FromUri]string idContato, [FromBody]AtualizarCmd parametros)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (!object.Equals(parametros, null))
                parametros.Id = idContato;

            _app.Atualizar(parametros);

            return CustomResponse(parametros);
        }

        [HttpDelete, Route("{idContato}")]
        [Display(Name = "Deletar")]
        public async Task<HttpResponseMessage> Delete([FromUri]string idContato)
        {
            if (string.IsNullOrEmpty(idContato))
            {
                NotificarErro("Id não á válido");
                CustomResponse();
            }

            _app.Delete(idContato);

            return CustomResponse();
        }

        [HttpGet, Route]
        [Display(Name = "Filtrar")]
        public async Task<HttpResponseMessage> Get([FromUri] FiltrarCmd parametros)
        {
            if (object.Equals(parametros, null))
                parametros = new FiltrarCmd();

            Contato[] usuario = _app.Filtrar(parametros);
            return CustomResponse(usuario);
        }

        [HttpPost, Route]
        [Display(Name = "Inserir")]
        public async Task<HttpResponseMessage> Post([FromBody]InserirCmd parametros)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            _app.Inserir(parametros);

            return CustomResponse(parametros);

        }
    }
}