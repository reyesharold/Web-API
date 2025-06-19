using ApiFirstProj.Services;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class DeleteStudentHandler(IStudentServices studentServices) : IRequestHandler<DeleteStudentCommand, bool>
    {
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await studentServices.DeleteStudentViaIdAsync(request.Id);
        }
    }
}
