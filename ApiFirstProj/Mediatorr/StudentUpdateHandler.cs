using ApiFirstProj.DTO;
using ApiFirstProj.Services;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class StudentUpdateHandler(IStudentServices studentServices) : IRequestHandler<StudentUpdateCommand, StudentResponse>
    {
        public async Task<StudentResponse> Handle(StudentUpdateCommand request, CancellationToken cancellationToken)
        {
            StudentUpdateRequest updateRequest = new StudentUpdateRequest
            {
                Name = request.Name,
                Year = request.Year,
            };

            var result = await studentServices.UpdateStudentViaIdAsync(request.Id, updateRequest);
            return result;
        }
    }
}
