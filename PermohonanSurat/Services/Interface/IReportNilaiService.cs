using PermohonanSurat.Models;
using Microsoft.EntityFrameworkCore;

namespace PermohonanSurat.Views.Services.Interface
{
    public interface IReportNilaiService
    {
        IEnumerable<ReportNilai> GetAllReportNilai();
        ReportNilai GetReportNilaiById(int id);
        ReportNilai CreateReportNilai(ReportNilai report);
        ReportNilai UpdateReportNilai(ReportNilai report);
        bool DeleteReportNilai(int id);
    }
}
