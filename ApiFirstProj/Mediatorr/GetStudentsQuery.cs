using ApiFirstProj.DTO;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class GetStudentsQuery : IRequest<IEnumerable<StudentResponse>>
    {
    }
}
