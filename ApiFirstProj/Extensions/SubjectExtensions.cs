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
                Professor = subject.Professor.ToProfessorResponse(),
                Students = subject.StudentSubjects.Select(s => s.ToStudentSubjectResponse()).ToList(),
            };
        }
    }
}
