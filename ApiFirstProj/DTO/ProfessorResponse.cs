namespace ApiFirstProj.DTO
{
    public class ProfessorResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<SubjectResponse> Subjects { get; set; }
    }
}
