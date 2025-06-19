using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
