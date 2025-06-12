using ApiFirstProj.Entities;

namespace ApiFirstProj.DTO
{
    public class StudentSubjectAddRequest
    {
        public Guid StudentId { get; set; }
        public Guid SubjectId { get; set; }

        public StudentSubject ToStudentSubject()
        {
            return new StudentSubject
            {
                StudentId = StudentId,
                SubjectId = SubjectId
            };
        }
    }
}
