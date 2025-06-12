using System.ComponentModel.DataAnnotations;

namespace ApiFirstProj.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
