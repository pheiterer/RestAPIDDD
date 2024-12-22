namespace RestAPIDDD.Application.Dtos
{
    public class ClienteDto
    {
        public uint? Id { get; set; }
        
        public required string Nome { get; set; }

        public required string Sobrenome { get; set; }

        public required string Email { get; set; }
    }
}
