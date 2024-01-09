using Microsoft.AspNetCore.Mvc;
using PermohonanSurat.Models;
using PermohonanSurat.Services.Interface;
using PermohonanSurat.Views.Services.Interface;

namespace PermohonanSurat.Controllers
{
    public class JadwalSidangController : Controller
    {
        private readonly IJadwalSidangService _jadwalService;

        public JadwalSidangController(IJadwalSidangService jadwalService)
        {
            _jadwalService = jadwalService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllJadwalSidang()
        {
            var jadwalList = _jadwalService.GetAllJadwalSidang();
            return Ok(jadwalList);
        }
        [HttpPost]

        public IActionResult CreateJadwalSidang([FromBody] JadwalSidang jadwal)
        {
            _jadwalService.CreateJadwalSidang(jadwal);
            return CreatedAtAction(nameof(GetAllJadwalSidang), new { id = jadwal.IdSidang }, jadwal);
        }

        public IActionResult UpdateJadwalSidang(int id, [FromBody] JadwalSidang jadwal)
        {
            if (id != jadwal.IdSidang)
            {
                return BadRequest();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]

        public IActionResult DeleteJadwalSidang(int id)
        {
            var jadwal = _jadwalService.GetJadwalSidangById(id);
            if (jadwal == null)
            {
                return NotFound();
            }

            _jadwalService.DeleteJadwalSidang(id);

            return NoContent();
        }
    }
}
