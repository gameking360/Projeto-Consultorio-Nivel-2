using Microsoft.IdentityModel.Tokens;
using Projeto_Consultorio_Nivel_2.DTOs;
using Projeto_Consultorio_Nivel_2.Models;

namespace Projeto_Consultorio_Nivel_2.Mappers
{
    public class MedicoMapper
    {
       

        public static MedicoDTO ModelToDTO(Medico medico)
        {
            MedicoDTO medicoDTO = new MedicoDTO()
            {
                CRM = medico.CRM,
                DataAdmissão = medico.DataAdmissão,
                DataNascimento = medico.DataNascimento,
                Especialidade = medico.Especialidade,
                Genero = medico.Genero,
                Id = medico.Id,
                Nome = medico.Nome,
                Telefone = medico.Telefone,

            };
            foreach(var paciente in medico.Pacientes)
            {
                medicoDTO.Pacientes.Add(paciente.Nome);
            }
            return medicoDTO;
        }

        public static Medico CreateMedico(CreateMedicoDTO dto)
        {
            Medico medico = new Medico()
            {
                Telefone = dto.Telefone,
                Especialidade = dto.Especialidade,
                CRM = dto.CRM,
                DataAdmissão = dto.DataAdmissão,
                DataNascimento = dto.DataNascimento,
                Nome = dto.Nome,
                Genero = dto.Genero
            };

            return medico;
        }

        public static Medico DtoToEntity(Medico medico, MedicoDTO medicoDTO, DataContext context)
        {
            medico.DataAdmissão = medicoDTO.DataAdmissão;

            medico.DataNascimento = medicoDTO.DataNascimento;

            if(medicoDTO.Especialidade != "string" && !medicoDTO.Especialidade.IsNullOrEmpty()) medico.Especialidade = medicoDTO.Especialidade;
            if(medicoDTO.CRM != "string" && !medicoDTO.CRM.IsNullOrEmpty()) medico.CRM = medicoDTO.CRM;
            if(medicoDTO.Genero != "string" && !medicoDTO.Genero.IsNullOrEmpty()) medico.Genero = medicoDTO.Genero;
            if(medicoDTO.Telefone != "string" && !medicoDTO.Telefone.IsNullOrEmpty()) medico.Telefone = medicoDTO.Telefone;
            
            foreach(var paciente in medicoDTO.Pacientes)
            {
                var p = context.Pacientes.FirstOrDefault(p => p.Nome.ToLower() == paciente.ToLower());
                medico.Pacientes.Add(p);

            }
            return medico;
        }
    }
}
