using Projeto_Consultorio_Nivel_2.DTOs;
using Projeto_Consultorio_Nivel_2.Models;

namespace Projeto_Consultorio_Nivel_2.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<Consulta>> GetAllConsultasByPacienteAsync(int id);
        Task<List<Paciente>> GetAllPacienteMaiorQueAsync(int idade);
        Task<string> UpdatePacienteAsync(int id, PacienteDTO request);
        Task<string> CreatePacienteAsync(PacienteInsertDTO request);
        Task<string> UpdateEnderecoAsync(int id, string endereco);
    }
}
