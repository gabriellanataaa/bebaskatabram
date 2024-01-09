using Microsoft.AspNetCore.Mvc;
using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using PermohonanSurat.Views.Services.Interface;
using PermohonanSurat.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PermohonanSurat.Controllers
{
    public class PerusahaanController : Controller
    {
        private readonly IPerusahaanService _perusahaanService;

        public PerusahaanController(IPerusahaanService perusahaanService)
        {
            _perusahaanService = perusahaanService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllPerusahaan()
        {
            var perusahaanList = _perusahaanService.GetAllPerusahaan();
            return Ok(perusahaanList);
        }
        [HttpPost]

        public IActionResult CreatePerusahaan([FromBody] Perusahaan perusahaan)
        {
            _perusahaanService.CreatePerusahaan(perusahaan);
            return CreatedAtAction(nameof(GetAllPerusahaan), new { id = perusahaan.IdPerusahaan }, perusahaan);
        }
        [HttpPut("{id}")]

        public IActionResult UpdatePerusahaan(int id, [FromBody] Perusahaan perusahaan)
        {
            if (id != perusahaan.IdPerusahaan)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult DeletePerusahaan(int id)
        {
            var perusahaan = _perusahaanService.GetPerusahaanById(id);
            if (perusahaan == null)
            {
                return NotFound();
            }

            _perusahaanService.DeletePerusahaan(id);

            return NoContent();
        }
    }
}
