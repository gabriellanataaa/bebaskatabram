using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PermohonanSurat.Interfaces;
using PermohonanSurat.Models;


namespace PermohonanSurat.Controllers
{
    public class SuratSidangTugasAkhirController : Controller
    {
        private readonly ISidangTugasAkhirService _sidangService;

        public SuratSidangTugasAkhirController(ISidangTugasAkhirService sidangService)
        {
            _sidangService = sidangService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllSidangTugasAkhir()
        {
            var sidangList = _sidangService.GetAllSidangTugasAkhir();
            return Ok(sidangList);
        }
        [HttpPost]

        public IActionResult CreateSidangTugasAkhir([FromBody] SuratSidangTugasAkhir sidang)
        {
            _sidangService.CreateSidangTugasAkhir(sidang);
            return CreatedAtAction(nameof(GetAllSidangTugasAkhir), new { id = sidang.IdSidang }, sidang);
        }
        [HttpPut("{id}")]

        public IActionResult UpdateSidangTugasAkhir(int id, [FromBody] SuratSidangTugasAkhir sidang)
        {
            if (id != sidang.IdSidang)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var sidang = _sidangService.GetSidangTugasAkhirById(id);
            if (sidang == null)
            {
                return NotFound();
            }

            _sidangService.DeleteSidangTugasAkhir(id);

            return NoContent();
        }
    }
}
