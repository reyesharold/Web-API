using ApiFirstProj.DTO;

namespace ApiFirstProj.Services
{
    public interface IStudentServices
    {
        Task<StudentResponse> AddStudentAsync(StudentAddRequest student);
        Task<StudentResponse> GetStudentViaIdAsync(Guid id);
        Task<ICollection<StudentResponse>> GetAllStudents();
        Task<StudentResponse> UpdateStudentViaIdAsync(Guid id, StudentUpdateRequest request);
        Task<bool> DeleteStudentViaIdAsync(Guid id);
    }
}
