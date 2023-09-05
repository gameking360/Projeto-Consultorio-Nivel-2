using Projeto_Consultorio_Nivel_2.DTOs;
using Projeto_Consultorio_Nivel_2.Models;

namespace Projeto_Consultorio_Nivel_2.Services.Interfaces
{
    public interface IMedicoInterface
    {

        public Task<List<Consulta>> GetConsultasByMedico(int medicoID);
        public Task<List<MedicoDTO>> GetMedicoByEspecialidade(string especialidade);
        public Task<int?> CreateMedico(CreateMedicoDTO medico);
        public Task<int?> UpdateMedico(MedicoDTO medico);
        public Task<int?> UpdateEspecialidade(int idMedico, string especialidade);




    }
}
