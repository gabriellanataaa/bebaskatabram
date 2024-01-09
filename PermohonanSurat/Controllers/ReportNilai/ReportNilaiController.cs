using Microsoft.AspNetCore.Mvc;
using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using PermohonanSurat.Views.Services.Interface;
using PermohonanSurat.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PermohonanSurat.Controllers
{
    public class ReportNilaiController : Controller
    {
        private readonly IReportNilaiService _reportnilaiService;

        public ReportNilaiController(IReportNilaiService reportnilaiService)
        {
            _reportnilaiService = reportnilaiService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllReportNilai()
        {
            var reportnilaiList = _reportnilaiService.GetAllReportNilai();
            return Ok(reportnilaiList);
        }
        [HttpPost]

        public IActionResult CreateReportNilai([FromBody] ReportNilai reportnilai)
        {
            _reportnilaiService.CreateReportNilai(reportnilai);
            return CreatedAtAction(nameof(GetAllReportNilai), new { id = reportnilai.IdReportNilai }, reportnilai);
        }
        [HttpPut("{id}")]

        public IActionResult UpdateReportNilai(int id, [FromBody] ReportNilai report)
        {
            if (id != report.IdReportNilai)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteReportNilai(int id)
        {
            var report = _reportnilaiService.GetReportNilaiById(id);
            if (report == null)
            {
                return NotFound();
            }

            _reportnilaiService.DeleteReportNilai(id);

            return NoContent();
        }
    }
}