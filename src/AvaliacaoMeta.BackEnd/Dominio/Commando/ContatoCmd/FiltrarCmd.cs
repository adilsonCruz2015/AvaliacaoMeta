namespace AvaliacaoMeta.BackEnd.Dominio.Commando.ContatoCmd
{
    public class FiltrarCmd
    {
        public FiltrarCmd()
        {
            Size = 10;
            Page = 1;
        }

        public int Size { get; set; }

        public int Page { get; set; }
    }
}
