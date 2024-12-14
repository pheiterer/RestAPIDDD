namespace RestAPIDDD.Domain.Entities
{
    public class Produto : Base
    {
        public required string Nome { get; set; }
        public required decimal Valor { get; set; }
        public bool IsDisponivel { get; set; }
    }
}
