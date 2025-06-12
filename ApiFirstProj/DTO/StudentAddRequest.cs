using ApiFirstProj.Entities;

namespace ApiFirstProj.DTO
{
    public class StudentAddRequest
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }

        public Student ToStudent()
        {
            return new Student
            {
                Name = Name,
                Course = Course,
                Year = Year
            };
        }
    }
}
