using PermohonanSurat.Models;
using Microsoft.EntityFrameworkCore;


namespace PermohonanSurat.Views.Services.Interface
{
    public interface IMahasiswaService
    {
        IEnumerable<Mahasiswa> GetAllMahasiswa();
        Mahasiswa GetMahasiswaById(int nim);
        Mahasiswa CreateMahasiswa(Mahasiswa mahasiswa);
        Mahasiswa UpdateMahasiswa(Mahasiswa mahasiswa);
        bool DeleteMahasiswa(int nim);
    }
}
