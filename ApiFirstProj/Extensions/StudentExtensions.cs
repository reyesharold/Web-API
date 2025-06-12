using ApiFirstProj.DTO;
using ApiFirstProj.Entities;

namespace ApiFirstProj.Extensions
{
    public static class StudentExtensions
    {
        public static StudentResponse ToStudentResponse(this Student student)
        {
            return new StudentResponse
            {
                Id = student.Id,
                Name = student.Name,
                Course = student.Course,
                Year = student.Year,
                Subjects = student.StudentSubjects.Select(s => s.ToStudentSubjectResponse()).ToList(),
            };
        }
    }
}
