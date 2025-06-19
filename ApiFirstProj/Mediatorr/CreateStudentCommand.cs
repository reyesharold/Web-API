using ApiFirstProj.DTO;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class CreateStudentCommand : IRequest<StudentResponse>
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
    }
}
