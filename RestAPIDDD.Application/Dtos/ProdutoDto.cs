namespace RestAPIDDD.Application.Dtos
{
    public class ProdutoDto
    {
        public uint? Id { get; set; }
        public required string Nome { get; set; }
        public decimal Valor{ get; set; }
    }
}
