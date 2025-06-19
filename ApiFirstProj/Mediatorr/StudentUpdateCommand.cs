using ApiFirstProj.DTO;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class StudentUpdateCommand : IRequest<StudentResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
    }
}
