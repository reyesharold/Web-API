using ApiFirstProj.Entities;

namespace ApiFirstProj.DTO
{
    public class ProfessorAddRequest
    {
        public string Name { get; set; }

        public Professor ToProfessor()
        {
            return new Professor 
            { 
                Name = Name 
            };
        }
    }
}
