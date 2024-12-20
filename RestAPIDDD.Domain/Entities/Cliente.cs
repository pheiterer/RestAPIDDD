﻿namespace RestAPIDDD.Domain.Entities
{
    public class Cliente : Base
    {
        public required string Nome { get; set; }
        public required string Sobrenome { get; set; }
        public required string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsAtivo { get; set; }
    }
}
