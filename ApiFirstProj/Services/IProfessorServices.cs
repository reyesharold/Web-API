using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;

namespace ApiFirstProj.Services
{
    public interface IProfessorServices
    {
        Task<ProfessorResponse> AddProfessorAsync(ProfessorAddRequest professor);
        Task<ProfessorResponse> GetProfessorViaIdAsync(Guid id);
        Task<ICollection<ProfessorResponse>> GetAllProfessors();
        Task<ProfessorResponse> UpdateProfessorViaIdAsync(Guid id, ProfessorUpdateRequest request);
        Task<bool> DeleteProfessorViaIdAsync(Guid id);
    }
}
