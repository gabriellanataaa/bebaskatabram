using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Views.Services.Interface;

namespace PermohonanSurat.Services
{
    public class MahasiswaService : IMahasiswaService
    {
        private readonly PermohonanSuratContext _mahasiswaService;

        public MahasiswaService(PermohonanSuratContext dbContext)
        {
            this._mahasiswaService = dbContext;
        }
        public IEnumerable<Mahasiswa> GetAllMahasiswa()
        {
            var Mahasiswa = _mahasiswaService.Mahasiswas.ToList();
            return Mahasiswa;
        }

        public Mahasiswa GetMahasiswaById(int nim)
        {
            Mahasiswa pelajar = _mahasiswaService.Mahasiswas.Where(x => x.Nim == nim).FirstOrDefault();
            return pelajar;
        }

        public Mahasiswa CreateMahasiswa(Mahasiswa mahasiswa)
        {
            var Mahasiswa = new Mahasiswa();
            mahasiswa.Nim = mahasiswa.Nim;
            mahasiswa.NamaMahasiswa = mahasiswa.NamaMahasiswa;

            _mahasiswaService.Add(mahasiswa);
            _mahasiswaService.SaveChanges();
            return mahasiswa;
        }

        public Mahasiswa UpdateMahasiswa(Mahasiswa mahasiswa)
        {
            var existingMahasiswa = _mahasiswaService.Mahasiswas.FirstOrDefault(x => x.Nim == mahasiswa.Nim);
            if (existingMahasiswa != null)
            {
                existingMahasiswa.NamaMahasiswa = mahasiswa.NamaMahasiswa;
                existingMahasiswa.Alamat = mahasiswa.Alamat;
                _mahasiswaService.SaveChanges();
                return existingMahasiswa;
            }
            else
            {
                throw new Exception("Mahasiswa not found");
            }
        }

        public bool DeleteMahasiswa(int nim)
        {
            var mahasiswa = _mahasiswaService.Mahasiswas.Where(x => x.Nim == nim).FirstAsync();

            if (mahasiswa != null)
            {
                _mahasiswaService.Remove(mahasiswa);
                _mahasiswaService.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Mahasiswa tidak ditemukan");
            }

        }
    }
}
