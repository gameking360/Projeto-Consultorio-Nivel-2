﻿

namespace Projeto_Consultorio_Nivel_2.Services.Interfaces
{
    public interface IConsultaService
    {
        Task<Consulta> CreateConsultaAsync(ConsultaDTO consulta);
        Task<string> DeleteConsultaAsync(int id);
        Task<List<Consulta>> GetConsultasPorData(DateTime data);
    }
}
