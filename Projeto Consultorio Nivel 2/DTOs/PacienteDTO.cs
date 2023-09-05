﻿namespace Projeto_Consultorio_Nivel_2.DTOs
{
    public class PacienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
