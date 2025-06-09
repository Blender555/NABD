using AutoMapper;
using NABD.DTO;
using NABD.Models.Domain;
using System.ComponentModel.Design;

namespace NABD.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Patient Mappings
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, AddPatientDto>().ReverseMap();
            CreateMap<Doctor, GetAllDoctorsForPatientDto>();
            CreateMap<Guardian, GetAllGuardiansDto>();
            CreateMap<Report, GetAllReportsDto>();

            // Doctor Mappings
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Doctor, GetDoctorDto>().ReverseMap();
            CreateMap<Doctor, AddDoctorDto>().ReverseMap();
            CreateMap<AddDoctorDto, Doctor>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();
            CreateMap<UpdateDoctorDto, Doctor>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            // Nurse Mappings
            CreateMap<Nurse, GetNurseDto>();
            CreateMap<Nurse, AddNurseDto>();
            CreateMap<Nurse, UpdateNurseDto>();

            // Guardian Mappings
            CreateMap<Guardian, GuardianDto>().ReverseMap();
            CreateMap<Guardian, AddGuardianDto>().ReverseMap();
            CreateMap<Patient, GetPatientByGuardianIdDto>();
            CreateMap<Notification, GetAllNotificationsForGuardianDto>();
            CreateMap<Emergency, GetAllEmergenciesForGuardianDto>();

            // Report Mappings
            CreateMap<Report, AddReportDto>().ReverseMap();
            CreateMap<Report, UpdateReportDto>().ReverseMap();
            CreateMap<UpdateReportDto,Report>().ReverseMap();

            // Emergency Mappings
            //CreateMap<Emergency, EmergencyDto>().ReverseMap();

            //Tool Mappings
            CreateMap<Tool, ToolDto>().ReverseMap();
            CreateMap<CreateToolDto, Tool>().ReverseMap();

        }
    }
}
