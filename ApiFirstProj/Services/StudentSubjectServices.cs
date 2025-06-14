using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstProj.Services
{
    public class StudentSubjectServices : IStudentSubjectServices
    {
        private readonly ICommonRepo<StudentSubject> _commonRepo;

        public StudentSubjectServices(ICommonRepo<StudentSubject> commonRepo)
        {
            _commonRepo = commonRepo;
        }

        public async Task<StudentSubjectResponse> AssignSubjectToStudentAsync(StudentSubjectAddRequest request)
        {
            if (request == null) { throw new ArgumentNullException("Student details are empty!", nameof(request)); }

            var response = await _commonRepo.CreateAsync(request.ToStudentSubject());

            return new StudentSubjectResponse
            {
                StudentId = response.StudentId,
                SubjectId = response.SubjectId,
            };
        }

        public async Task<bool> DeleteStudentSubjectViaIdAsync(Guid studentId, Guid subjectId)
        {
            var studentSubject = await _commonRepo.GetAsync(id => id.StudentId == studentId && id.SubjectId == subjectId);
            if (studentSubject == null) return false;

            bool response = await _commonRepo.DeleteViaCompKeyAsync(id => id.StudentId == studentId && id.SubjectId == subjectId);
            if (!response) { throw new Exception($"Error deleting Subject {studentSubject.Subject.Name} of Student {studentSubject.Student.Name}"); }

            return response;
        }

        public async Task<ICollection<StudentSubjectResponse>> GetAllStudentSubjectAsync()
        {
            var response = await _commonRepo.GetAllAsync(null, query => query
            .Include(s => s.Student)
            .Include(s => s.Subject));

            if (response == null) { return null; }

            return response.Select(ss => ss.ToStudentSubjectResponse()).ToList();
        }

        public async Task<StudentSubjectResponse> GetStudentSubjectViaCompKeytAsync(Guid studentId, Guid subjectId)
        {
            var response = await _commonRepo.GetAsync(k => k.StudentId == studentId && k.SubjectId == subjectId, query => query
            .Include(s => s.Student)
            .Include(s => s.Subject));

            if (response == null) { return null; }
            return response.ToStudentSubjectResponse();
        }

        public async Task<StudentSubjectResponse> UpdateStudentSubejctViaCompKeyAsync(Guid studentId,Guid subjectId, StudentSubjectUpdateRequest request)
        {
            

            await DeleteStudentSubjectViaIdAsync(studentId, subjectId);

            var update = new StudentSubjectAddRequest
            {
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
            };

            var response = await AssignSubjectToStudentAsync(update);

            return response;
        }
    }
}
