using ApiFirstProj.DTO;
using ApiFirstProj.Entities;

namespace ApiFirstProj.Extensions
{
    public static class ProfessorExtensions
    {
        public static ProfessorResponse ToProfessorResponse(this Professor professor)
        {
            return new ProfessorResponse
            {
                Id = professor.Id,
                Name = professor.Name,
                Subjects = professor.Subjects != null ? professor.Subjects.Select(s => s.ToSubjectRespose()).ToList() : new List<SubjectResponse>(),
            };
        }
    }
}
