using ApiFirstProj.DTO;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class GetStudentViaIdQuery : IRequest<StudentResponse>
    {
        public Guid Id { get; set; }
    }
}
