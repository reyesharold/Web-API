using ApiFirstProj.DTO;
using ApiFirstProj.Services;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class GetStudentViaIdHandler : IRequestHandler<GetStudentViaIdQuery, StudentResponse>
    {
        private readonly IStudentServices _studentServices;

        public GetStudentViaIdHandler(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public async Task<StudentResponse> Handle(GetStudentViaIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentServices.GetStudentViaIdAsync(request.Id);
        }
    }
}
