using ApiFirstProj.DTO;

namespace ApiFirstProj.Services
{
    public interface ISubjectServices
    {
        Task<SubjectResponse> AddSubjectAsync(SubjectAddRequest student);
        Task<SubjectResponse> GetSubjectViaIdAsync(Guid id);
        Task<ICollection<SubjectResponse>> GetAllSubjects();
        Task<SubjectResponse> UpdateSubjectViaIdAsync(Guid id, SubjectUpdateRequest request);
        Task<bool> DeleteSubjectViaIdAsync(Guid id);
    }
}
