using ApiFirstProj.DTO;
using ApiFirstProj.Entities;

namespace ApiFirstProj.Extensions
{
    public static class StudentSubjectExtension
    {
        public static StudentSubjectResponse ToStudentSubjectResponse(this StudentSubject studentSubject)
        {
            return new StudentSubjectResponse
            {
                StudentId = studentSubject.StudentId,
                StudentName = studentSubject.Student.Name,
                SubjectId = studentSubject.SubjectId,
                SubjectName = studentSubject.Subject.Name,
            };
        }
    }
}
