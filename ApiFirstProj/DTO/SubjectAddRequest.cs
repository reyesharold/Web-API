using ApiFirstProj.Entities;

namespace ApiFirstProj.DTO
{
    public class SubjectAddRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProfessorId { get; set; }

        public Subject ToSubject()
        {
            return new Subject
            {
                Name = Name,
                Description = Description,
                ProfessorId = ProfessorId
            };
        }
    }
}
