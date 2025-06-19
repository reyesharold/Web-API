using ApiFirstProj.DTO;
using ApiFirstProj.Mediatorr;
using AutoMapper;

namespace ApiFirstProj.Core
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<CreateStudentCommand, StudentAddRequest>();
            CreateMap<StudentAddRequest, CreateStudentCommand>();
        }
    }
}
