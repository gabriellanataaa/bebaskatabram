using PermohonanSurat.Models;

namespace PermohonanSurat.Services.Interface
{
    public interface IJadwalSidangService
    {
        IEnumerable<JadwalSidang> GetAllJadwalSidang();
        JadwalSidang GetJadwalSidangById(int id);
        JadwalSidang CreateJadwalSidang(JadwalSidang jadwal);
        JadwalSidang UpdateJadwalSidang(JadwalSidang jadwal);
        bool DeleteJadwalSidang(int id);
    }
}
