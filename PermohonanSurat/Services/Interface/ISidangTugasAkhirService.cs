using Microsoft.EntityFrameworkCore;
using PermohonanSurat.Models;

namespace PermohonanSurat.Interfaces
{
    public interface ISidangTugasAkhirService
    {
        IEnumerable<SuratSidangTugasAkhir> GetAllSidangTugasAkhir();
        SuratSidangTugasAkhir GetSidangTugasAkhirById(int id);
        SuratSidangTugasAkhir CreateSidangTugasAkhir(SuratSidangTugasAkhir sidang);
        SuratSidangTugasAkhir UpdateSidangTugasAkhir(SuratSidangTugasAkhir sidang);
        bool DeleteSidangTugasAkhir(int id);
    }
}