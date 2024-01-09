using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Views.Services.Interface;

namespace PermohonanSurat.Services
{
    public class PerusahaanService : IPerusahaanService
    {
        private readonly PermohonanSuratContext _perusahaanService;

        public PerusahaanService(PermohonanSuratContext dbContext)
        {
            this._perusahaanService = dbContext;
        }
        public IEnumerable<Perusahaan> GetAllPerusahaan()
        {
            var Perusahaan = _perusahaanService.Perusahaans.ToList();
            return Perusahaan;
        }

        public Perusahaan GetPerusahaanById(int id)
        {
            Perusahaan perusahaan = _perusahaanService.Perusahaans.Where(x => x.IdPerusahaan == id).FirstOrDefault();
            return perusahaan;
        }

        public Perusahaan CreatePerusahaan(Perusahaan perusahaan)
        {
            var Perusahaan = new Perusahaan();

            perusahaan.AlamatPerusahaan = perusahaan.AlamatPerusahaan;

            _perusahaanService.Add(perusahaan);
            _perusahaanService.SaveChanges();
            return perusahaan;
        }

        public Perusahaan UpdatePerusahaan(Perusahaan perusahaan)
        {
            var existingPerusahaan = _perusahaanService.Perusahaans.FirstOrDefault(x => x.IdPerusahaan == perusahaan.IdPerusahaan);
            if (existingPerusahaan != null)
            {
                existingPerusahaan.NamaPerusahaan = perusahaan.NamaPerusahaan;
                existingPerusahaan.AlamatPerusahaan = perusahaan.AlamatPerusahaan;
                _perusahaanService.SaveChanges();
                return existingPerusahaan;
            }
            else
            {
                throw new Exception("Perusahaan not found");
            }
        }

        public bool DeletePerusahaan(int id)
        {
            var perusahaanToDelete = _perusahaanService.Perusahaans.FirstOrDefault(x => x.IdPerusahaan == id);

            if (perusahaanToDelete != null)
            {
                _perusahaanService.Remove(perusahaanToDelete);
                _perusahaanService.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Perusahaan tidak ditemukan");
                // Alternatively, you can handle this case without throwing an exception
                // and return false or take appropriate action.
            }
        }
    }
}
