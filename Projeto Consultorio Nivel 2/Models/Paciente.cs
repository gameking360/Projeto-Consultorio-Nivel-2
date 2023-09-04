﻿namespace Projeto_Consultorio_Nivel_2.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Medico> Medicos { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
    }
}
