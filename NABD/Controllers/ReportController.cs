using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NABD.DTO;
using NABD.Models.Domain;
using NABD.Repositories;
using ClosedXML.Excel;
using System.IO;

namespace NABD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository reportRepsitory;
        private readonly IMapper mapper;

        public ReportController(IReportRepository reportRepsitory, IMapper mapper)
        {
            this.reportRepsitory = reportRepsitory;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int pageSize = 1000)
        {
            var reports = await reportRepsitory.GetAll(pageNumber, pageSize);
            return Ok(reports);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var report = await reportRepsitory.GetById(id);
            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddReportDto addReport)
        {
            var reportModel = mapper.Map<Report>(addReport);
            await reportRepsitory.Create(reportModel);

            var reportDto = mapper.Map<Report>(reportModel);
            return Ok(reportDto);
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateReportDto updateReport)
        {
            var updatedReport = await reportRepsitory.Update(id, mapper.Map<Report>(updateReport));

            if (updatedReport == null)
            {
                return NotFound($"Report with ID {id} not found!");
            }

            var reportDto = mapper.Map<UpdateReportDto>(updatedReport);
            return Ok(reportDto);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var report = await reportRepsitory.Delete(id);
            if (report == null)
            {
                return NotFound($"Report with ID {id} not found!");
            }

            var reportDto = mapper.Map<Report>(report);
            return Ok(reportDto);
        }

        [HttpGet]
        [Route("patient/{patientId}")]
        public async Task<IActionResult> GetReportsByPatientId(int patientId)
        {
            var reports = await reportRepsitory.GetReportsByPatientId(patientId);
            if (reports == null || reports.Count == 0)
                return NotFound($"No reports found for patient with ID {patientId}");

            var reportsDto = mapper.Map<List<UpdateReportDto>>(reports);
            return Ok(reportsDto);
        }

        [HttpGet]
        [Route("patient/{patientId}/medicalhistory")]
        public async Task<IActionResult> ExportReportsToExcel(int patientId)
        {
            var reports = await reportRepsitory.GetReportsByPatientId(patientId);
            if (reports == null || reports.Count == 0)
                return NotFound($"No reports found for patient with ID {patientId}");

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Patient Reports");

            // Header row
            worksheet.Cell(1, 1).Value = "Upload Date";
            worksheet.Cell(1, 2).Value = "Diagnosis";
            worksheet.Cell(1, 3).Value = "Medication";

            int currentRow = 2;

            foreach (var report in reports)
            {
                worksheet.Cell(currentRow, 1).Value = report.UploadDate.ToString("yyyy-MM-dd");
                worksheet.Cell(currentRow, 2).Value = report.Diagnosis;
                worksheet.Cell(currentRow, 3).Value = report.Medication;
                currentRow++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Seek(0, SeekOrigin.Begin);

            var fileName = $"Patient_{patientId}_Reports_{DateTime.UtcNow:yyyyMMddHHmmss}.xlsx";
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
    }
}
