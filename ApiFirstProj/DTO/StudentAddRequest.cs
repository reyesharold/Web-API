using ApiFirstProj.Entities;
using System.ComponentModel.DataAnnotations;

namespace ApiFirstProj.DTO
{
    public class StudentAddRequest
    {
        [Required(ErrorMessage = "Name can't be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course can't be empty")]
        public string Course { get; set; }
        [Required(ErrorMessage = "Year can't be empty")]
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
