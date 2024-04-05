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

            CreateMap<CourseAssignment, CourseAssignmentDto>();
            CreateMap<Course, CourseDto>();
            CreateMap<CourseForCreationDto, Course>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentForCreationDto, Department>();
            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<EnrollmentForCreationDto, Enrollment>();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<InstructorForCreationDto, Instructor>();
            CreateMap<OfficeAssignment, OfficeAssignmentDto>();
            CreateMap<StudentForCreationDto, Student>();
            CreateMap<StudentForUpdateDto, Student>().ReverseMap();
            CreateMap<Student, StudentWithEnrollmentsDto>();
            CreateMap<EnrollmentForUpdateDto, Enrollment>();
            CreateMap<UserForRegistrationDto, User>();
        }
    }
}
