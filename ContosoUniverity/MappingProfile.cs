using AutoMapper;
using Entities;
using Shared.DataTransferObjects;

namespace ContosoUniversity
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(c => c.FullName, 
                           opt => opt.MapFrom(src => $"{src.FirstMidName} {src.LastName}"));
                //.ForCtorParam("FullName", opt => 
                //              opt.MapFrom(src => $"{src.FirstMidName} {src.LastName}"));

            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<StudentForCreationDto, Student>();
        }
    }
}
