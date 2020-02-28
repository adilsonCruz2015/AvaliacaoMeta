namespace AvaliacaoMeta.BackEnd.Dominio.Interfaces
{
    public interface IAutoValidacao
    {
        INotificador Notificador { get; }

        bool EhValido();
    }
}
