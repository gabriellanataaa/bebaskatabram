using PermohonanSurat.Models;
using PermohonanSurat.Services.Interface;

namespace PermohonanSurat.Services
{
    public class JadwalSidangService : IJadwalSidangService
    {
        private readonly PermohonanSuratContext _jadwalService;

        public JadwalSidangService(PermohonanSuratContext dbContext)
        {
            this._jadwalService = dbContext;
        }

        public IEnumerable<JadwalSidang> GetAllJadwalSidang()
        {
            var jadwalSidangList = _jadwalService.JadwalSidangs.ToList();
            return jadwalSidangList;
        }

        public JadwalSidang GetJadwalSidangById(int id)
        {
            JadwalSidang jadwal = _jadwalService.JadwalSidangs.FirstOrDefault(x => x.IdSidang == id);
            return jadwal;
        }

        public JadwalSidang CreateJadwalSidang(JadwalSidang jadwal)
        {
            _jadwalService.Add(jadwal);
            _jadwalService.SaveChanges();
            return jadwal;
        }

        public JadwalSidang UpdateJadwalSidang(JadwalSidang jadwal)
        {
            var existingJadwalSidang = _jadwalService.JadwalSidangs.FirstOrDefault(x => x.IdSidang == jadwal.IdSidang);
            if (existingJadwalSidang != null)
            {
                existingJadwalSidang.JudulTugasAkhir = jadwal.JudulTugasAkhir;
                existingJadwalSidang.TanggalSidang = jadwal.TanggalSidang;
                _jadwalService.SaveChanges();
                return existingJadwalSidang;
            }
            else
            {
                throw new Exception("Jadwal Sidang not found");
            }
        }

        public bool DeleteJadwalSidang(int id)
        {
            var jadwal = _jadwalService.JadwalSidangs.FirstOrDefault(x => x.IdSidang == id);

            if (jadwal != null)
            {
                _jadwalService.Remove(jadwal);
                _jadwalService.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Jadwal Sidang tidak ditemukan");
            }
        }
    }
}
