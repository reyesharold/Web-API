namespace ApiFirstProj.DTO
{
    public class SubjectResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProfessorName { get; set; }
        public ICollection<StudentSubjectResponse> Students { get; set; }
    }
}
