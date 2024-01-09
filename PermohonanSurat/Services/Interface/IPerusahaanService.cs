using PermohonanSurat.Models;
using Microsoft.EntityFrameworkCore;

namespace PermohonanSurat.Views.Services.Interface
{
    public interface IPerusahaanService
    {
        IEnumerable<Perusahaan> GetAllPerusahaan();
        Perusahaan GetPerusahaanById(int id);
        Perusahaan CreatePerusahaan(Perusahaan perusahaan);
        Perusahaan UpdatePerusahaan(Perusahaan perusahaan);
        bool DeletePerusahaan(int id);
    }
}
