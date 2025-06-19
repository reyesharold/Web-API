using ApiFirstProj.DTO;
using ApiFirstProj.Services;
using MediatR;

namespace ApiFirstProj.Mediatorr
{
    public class GetStudentsHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentResponse>>
    {
        private readonly IStudentServices _studentServices;

        public GetStudentsHandler(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        public async Task<IEnumerable<StudentResponse>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _studentServices.GetAllStudents(cancellationToken);
        }
    }
}
