namespace ApiFirstProj.DTO
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
        public ICollection<StudentSubjectResponse> Subjects { get; set; }

    }
}
