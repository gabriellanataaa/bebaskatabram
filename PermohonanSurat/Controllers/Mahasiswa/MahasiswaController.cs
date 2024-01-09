using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using PermohonanSurat.Models; // Update this with the correct namespace
using PermohonanSurat.Services; // Update this with the correct namespace
using PermohonanSurat.Views.Services.Interface;

public class MahasiswaController : Controller
{
    private readonly IMahasiswaService _mahasiswaService;

    public MahasiswaController(IMahasiswaService mahasiswaService)
    {
        _mahasiswaService = mahasiswaService;
    }

    public IActionResult Index()
    {
        return View();
    }

    // GET: api/Mahasiswa
    [HttpGet]

    public IActionResult GetAllMahasiswa()
    {
        var mahasiswaList = _mahasiswaService.GetAllMahasiswa();
        return Ok(mahasiswaList);
    }

    // POST: api/Mahasiswa
    [HttpPost]
    public IActionResult CreateMahasiswa([FromBody] Mahasiswa mahasiswa)
    {
        _mahasiswaService.CreateMahasiswa(mahasiswa);
        return CreatedAtAction(nameof(GetAllMahasiswa), new { id = mahasiswa.Nim }, mahasiswa);
    }

    [HttpPut("{nim}")]
    public IActionResult UpdateMahasiswa(int nim, [FromBody] Mahasiswa mahasiswa)
    {
        if (nim != mahasiswa.Nim)
        {
            return BadRequest();
        }
        return NoContent();
    }

    // DELETE: api/Mahasiswa/5
    [HttpDelete("{nim}")]

    public IActionResult DeleteMahasiswa(int nim)
    {
        var mahasiswa = _mahasiswaService.GetMahasiswaById(nim);
        if (mahasiswa == null)
        {
            return NotFound();
        }

        _mahasiswaService.DeleteMahasiswa(nim);

        return NoContent();
    }
}

