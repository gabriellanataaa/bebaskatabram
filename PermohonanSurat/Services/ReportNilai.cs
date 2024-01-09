using PermohonanSurat.Models;
using PermohonanSurat.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Views.Services.Interface;


namespace PermohonanSurat.Services
{
    public class ReportNilaiService : IReportNilaiService
    {
        private readonly PermohonanSuratContext _reportnilaiService;

        public ReportNilaiService(PermohonanSuratContext dbContext)
        {
            this._reportnilaiService = dbContext;
        }
        public IEnumerable<ReportNilai> GetAllReportNilai()
        {
            var ReportNilai = _reportnilaiService.ReportNilais.ToList();
            return ReportNilai;
        }

        public ReportNilai GetReportNilaiById(int id)
        {
            ReportNilai report = _reportnilaiService.ReportNilais.Where(x => x.IdReportNilai == id).FirstOrDefault();
            return report;
        }

        public ReportNilai CreateReportNilai(ReportNilai report)
        {
            var ReportNilai = new ReportNilai();
            report.Nim = report.Nim;
            report.NamaSiswa = report.NamaSiswa;

            _reportnilaiService.Add(report);
            _reportnilaiService.SaveChanges();
            return report;
        }

        public ReportNilai UpdateReportNilai(ReportNilai report)
        {
            var existingReportNilai = _reportnilaiService.ReportNilais.FirstOrDefault(x => x.IdReportNilai == report.IdReportNilai);
            if (existingReportNilai != null)
            {
                existingReportNilai.Nim = report.Nim;
                existingReportNilai.NamaSiswa = report.NamaSiswa;
                _reportnilaiService.SaveChanges();
                return existingReportNilai;
            }
            else
            {
                throw new Exception("Report Nilai not found");
            }
        }

        public bool DeleteReportNilai(int id)
        {
            var report = _reportnilaiService.ReportNilais.FirstOrDefault(x => x.IdReportNilai == id);

            if (report != null)
            {
                _reportnilaiService.Remove(report);
                _reportnilaiService.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Report Nilai tidak ditemukan");
            }
        }

    }
}
