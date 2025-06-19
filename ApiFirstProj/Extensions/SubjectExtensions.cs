using ApiFirstProj.DTO;
using ApiFirstProj.Entities;

namespace ApiFirstProj.Extensions
{
    public static class SubjectExtensions
    {
        public static SubjectResponse ToSubjectRespose(this Subject subject)
        {
            return new SubjectResponse
            {
                Id = subject.Id,
                Name = subject.Name,
                Description = subject.Description,
                ProfessorName = subject.Professor.Name,
                Students = subject.StudentSubjects != null ? subject.StudentSubjects.Select(s => s.ToStudentSubjectResponse()).ToList() : new List<StudentSubjectResponse>(),
            };
        }
    }
}
