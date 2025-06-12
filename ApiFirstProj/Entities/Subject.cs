using System.ComponentModel.DataAnnotations;

namespace ApiFirstProj.Entities
{
    public class Subject
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
