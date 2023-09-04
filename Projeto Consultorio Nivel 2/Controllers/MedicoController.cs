using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Consultorio_Nivel_2.DTOs;
using Projeto_Consultorio_Nivel_2.Models;
using Projeto_Consultorio_Nivel_2.Services.Interfaces;

namespace Projeto_Consultorio_Nivel_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoInterface _medicoInterface;

        public MedicoController(IMedicoInterface medicoInterface)
        {
            _medicoInterface = medicoInterface;
        }

        [HttpGet("medicos/{id}")]
        public async Task<ActionResult<List<Consulta>>> GetConsultaByMedico(int id)
        {
           List<Consulta> list = await _medicoInterface.GetConsultasByMedico(id);
            if (!list.Any()) return NotFound("Não há nenhuma consulta para esse médico");

            return Ok(list);
        }

        [HttpGet("medicos/especilaidade={especialidade}")]
        public async Task<ActionResult<List<MedicoDTO>>> GetMedicoByEspecialidade(string especialidade)
        {
            List<MedicoDTO> medicos = await _medicoInterface.GetMedicoByEspecialidade(especialidade);
            if (!medicos.Any()) return NotFound("Nenhum médico com essa especialidade encontrado");

            return Ok(medicos);
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> CreateMedico(CreateMedicoDTO medicoDTO)
        {
            var resposta = _medicoInterface.CreateMedico(medicoDTO);
            if (resposta is null) return BadRequest("Erro ao criar o médico");
            
            return Ok("Médico criado com sucesso");
        }

        [HttpPut("medicos/{id}")]
        public async Task<IActionResult> UpdateMedico(int id,MedicoDTO dto)
        {
            if (id != dto.Id) return BadRequest("Ids devem ser iguais");
            var resposta = await _medicoInterface.UpdateMedico(dto);

            if (resposta == null) return BadRequest("Houve algum erro para atualizar o médico.");

            return Ok("Médico alterado com sucesso");

        }

        [HttpPatch("medicos/{id}")]
        public async Task<IActionResult> UpdateEspecialidadeMedico(int id, string especialidade)
        {
            var respota = _medicoInterface.UpdateEspecialidade(id, especialidade);
            if (respota is null) return BadRequest("Erro ao atualizar a especialidade");

            return Ok("Especialidade atualizada com sucesso");
        }
    }
}
