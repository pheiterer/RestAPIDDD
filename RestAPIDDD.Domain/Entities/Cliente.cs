namespace RestAPIDDD.Domain.Entities
{
    public class Cliente : Base
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required DateTime DataCadastro { get; set; }
        public bool IsAtivo { get; set; }
    }
}
