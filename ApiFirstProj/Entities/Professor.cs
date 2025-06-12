using System.ComponentModel.DataAnnotations;

namespace ApiFirstProj.Entities
{
    public class Professor
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
