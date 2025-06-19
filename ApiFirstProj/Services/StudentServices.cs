using ApiFirstProj.Common;
using ApiFirstProj.DTO;
using ApiFirstProj.Entities;
using ApiFirstProj.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ApiFirstProj.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly ICommonRepo<Student> _commonRepo;

        public StudentServices(ICommonRepo<Student> commonRepo)
        {
            _commonRepo = commonRepo;
        }

        public async Task<StudentResponse> AddStudentAsync(StudentAddRequest student)
        {
            if (student == null) { throw new ArgumentNullException("Student details are empty!",nameof(student)); }

            var response = await _commonRepo.CreateAsync(student.ToStudent());

            return response.ToStudentResponse();
        }

        public async Task<bool> DeleteStudentViaIdAsync(Guid id)
        {
            var student = await _commonRepo.GetAsync(s => s.Id == id);
            if (student == null) { throw new ArgumentException("Student ID not found",nameof(student)); }

            bool response = await _commonRepo.DeleteViaIdAsync(student.Id);
            if (!response) { throw new Exception($"Error deleting Student {student.Id}"); }

            return response;
        }

        public async Task<ICollection<StudentResponse>> GetAllStudents()
        {
            var response = await _commonRepo.GetAllAsync(null, query => query
            .Include(s => s.StudentSubjects)
                .ThenInclude(s => s.Subject)
            );

            return response.Select(temp => temp.ToStudentResponse()).ToList();
        }

        public async Task<StudentResponse> GetStudentViaIdAsync(Guid id)
        {
            var response = await _commonRepo.GetAsync(s => s.Id == id, query => query
            .Include(s => s.StudentSubjects)
                .ThenInclude(s => s.Subject));

            return response.ToStudentResponse();
        }

        public async Task<StudentResponse> UpdateStudentViaIdAsync(Guid id, StudentUpdateRequest request)
        {
            var student = await _commonRepo.GetAsync(s => s.Id == id, query => query
            .Include(s => s.StudentSubjects)
                .ThenInclude(s => s.Subject));
            if (student == null) { return null;}

            student.Name = request.Name;
            student.Year = request.Year;

            var response = await _commonRepo.UpdateAsync(student, n => n.Name, y => y.Year);

            return response.ToStudentResponse();
        }
    }
}
