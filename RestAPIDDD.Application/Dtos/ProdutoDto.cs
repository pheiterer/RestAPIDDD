namespace RestAPIDDD.Application.Dtos
{
    public sealed class ProdutoDto
    {
        public uint? Id { get; set; }
        public required string Nome { get; set; }
        public decimal Valor{ get; set; }
    }
}
