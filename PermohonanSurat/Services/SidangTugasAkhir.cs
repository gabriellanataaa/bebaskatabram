using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Views.Services.Interface;


namespace PermohonanSurat.Services
{
    public class SidangTugasAkhirService : ISidangTugasAkhirService
    {
        private readonly PermohonanSuratContext _sidangtugasakhirService;

        public SidangTugasAkhirService(PermohonanSuratContext dbContext)
        {
            this._sidangtugasakhirService = dbContext;
        }
        public IEnumerable<SuratSidangTugasAkhir> GetAllSidangTugasAkhir()
        {
            var SidangTugasAkhir = _sidangtugasakhirService.SidangTugasAkhirs.ToList();
            return SidangTugasAkhir;
        }

        public SuratSidangTugasAkhir GetSidangTugasAkhirById(int id)
        {
            SuratSidangTugasAkhir sidang = _sidangtugasakhirService.SidangTugasAkhirs.Where(x => x.IdSidang == id).FirstOrDefault();
            return sidang;
        }

        public SuratSidangTugasAkhir CreateSidangTugasAkhir(SuratSidangTugasAkhir sidang)
        {
            var SidangTugasAkhir = new SuratSidangTugasAkhir();
            sidang.JudulTugasAkhir = sidang.JudulTugasAkhir;
            sidang.TanggalSidang = sidang.TanggalSidang;

            _sidangtugasakhirService.Add(sidang);
            _sidangtugasakhirService.SaveChanges();
            return sidang;
        }

        public SuratSidangTugasAkhir UpdateSidangTugasAkhir(SuratSidangTugasAkhir sidang)
        {
            var existingSidangTugasAkhir = _sidangtugasakhirService.SidangTugasAkhirs.FirstOrDefault(x => x.IdSidang == sidang.IdSidang);
            if (existingSidangTugasAkhir != null)
            {
                existingSidangTugasAkhir.JudulTugasAkhir = sidang.JudulTugasAkhir;
                existingSidangTugasAkhir.TanggalSidang = sidang.TanggalSidang;
                _sidangtugasakhirService.SaveChanges();
                return existingSidangTugasAkhir;
            }
            else
            {
                throw new Exception("Surat Sidang Tugas Akhir not found");
            }
        }

        public bool DeleteSidangTugasAkhir(int id)
        {
            var report = _sidangtugasakhirService.SidangTugasAkhirs.FirstOrDefault(x => x.IdSidang == id);

            if (report != null)
            {
                _sidangtugasakhirService.Remove(report);
                _sidangtugasakhirService.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Surat Sidang Tugas Akhir tidak ditemukan");
            }
        }
    }
}
