using FluentValidation;

namespace AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd.Validacao
{
    public class FiltrarValidacao : AbstractValidator<FiltrarCmd>
    {
        public FiltrarValidacao()
        {
            RuleFor(f => f.Page).GreaterThan(-1).WithMessage("O campo {PropertyName} precisa ser maior que zero");

            RuleFor(f => f.Size).GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que zero");
        }
    }
}
