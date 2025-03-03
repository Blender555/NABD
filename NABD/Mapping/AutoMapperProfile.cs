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
            CreateMap<MedicalHistory, GetMedicalHistoryDto>();
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

            // Medical History Mappings
            CreateMap<MedicalHistory, AddMedicalHistoryDto>().ReverseMap();
            CreateMap<MedicalHistory, GetMedicalHistoryDto>().ReverseMap();
            CreateMap<MedicalHistory, UpdateMedicalHistoryDto>().ReverseMap();

            // Report Mappings
            CreateMap<Report, AddReportDto>().ReverseMap();
            CreateMap<Report, UpdateReportDto>().ReverseMap();

            // Emergency Mappings
            //CreateMap<Emergency, EmergencyDto>().ReverseMap();

            //Tool Mappings
            CreateMap<Tool, ToolDto>().ReverseMap();
            CreateMap<CreateToolDto, Tool>().ReverseMap();

        }
    }
}
