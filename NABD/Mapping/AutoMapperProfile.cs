using AutoMapper;
using NABD.DTO;
using NABD.Models.Domain;
using NABD.Models.Domain;
using System.ComponentModel.Design;

namespace NABD.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // **Patient Mappings**
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Patient, AddPatientDto>().ReverseMap();
            CreateMap<MedicalStaff, GetAllDoctorsForPatientDto>();
            CreateMap<Guardian, GetAllGuardiansDto>();
            CreateMap<MedicalHistory, GetMedicalHistoryDto>();
            CreateMap<Report, GetAllReportsDto>();

            //// **Medical Staff Mappings**
            //CreateMap<MedicalStaff, MedicalStaffDto>().ReverseMap();
            //CreateMap<MedicalStaff, AddMedicalStaffDto>().ReverseMap();
            //CreateMap<Patient, GetAllPatientsForMedicalStaffDto>();
            //CreateMap<Notification, GetAllNotificationsForMedicalStaffDto>();
            //CreateMap<Emergency, GetAllEmergenciesForMedicalStaffDto>();

            //// **Guardian Mappings**
            //CreateMap<Guardian, GuardianDto>().ReverseMap();
            //CreateMap<Guardian, AddGuardianDto>().ReverseMap();
            //CreateMap<Patient, GetPatientByGuardianDto>();
            //CreateMap<Notification, GetAllNotificationsForGuardianDto>();
            //CreateMap<Emergency, GetAllEmergenciesForGuardianDto>();

            //// **Medical History Mappings**
            //CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
            //CreateMap<MedicalHistory, AddMedicalHistoryDto>().ReverseMap();

            //// **Report Mappings**
            //CreateMap<Report, ReportDto>().ReverseMap();
            //CreateMap<Report, AddReportDto>().ReverseMap();

            //// **Emergency Mappings**
            //CreateMap<Emergency, EmergencyDto>().ReverseMap();
            //CreateMap<Emergency, AddEmergencyDto>().ReverseMap();

            //// **Tool Mappings**
            //CreateMap<Tool, ToolDto>().ReverseMap();
            //CreateMap<Tool, AddToolDto>().ReverseMap();

        }
    }
}
