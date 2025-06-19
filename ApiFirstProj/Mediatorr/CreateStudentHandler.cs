using ApiFirstProj.DTO;
using ApiFirstProj.Services;
using AutoMapper;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class CreateStudentHandler(IStudentServices _studentServices, IMapper mapper) : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            StudentAddRequest student = mapper.Map<StudentAddRequest>(request);
            return await _studentServices.AddStudentAsync(student);
        }
    }
}
