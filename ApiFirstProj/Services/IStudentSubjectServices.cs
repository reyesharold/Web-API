using ApiFirstProj.DTO;

namespace ApiFirstProj.Services
{
    public interface IStudentSubjectServices
    {
        Task<StudentSubjectResponse> AssignSubjectToStudentAsync(StudentSubjectAddRequest request);
        Task<StudentSubjectResponse> GetStudentSubjectViaCompKeytAsync(Guid studentId, Guid subjectId);
        Task<ICollection<StudentSubjectResponse>> GetAllStudentSubjectAsync();
        Task<StudentSubjectResponse> UpdateStudentSubejctViaCompKeyAsync(Guid studentId, Guid subjectId, StudentSubjectUpdateRequest request);
        Task<bool> DeleteStudentSubjectViaIdAsync(Guid studentId, Guid subjectId);
    }
}
