namespace PermohonanSurat.Models
{
    public class JadwalSidang
    {
        public int IdSidang { get; set; }
        public string NamaMahasiswa { get; set; } = null!;
        public int Nim { get; set; }
        public string JudulTugasAkhir { get; set; } = null!;
        public string Hari { get; set; } = null!;
        public DateTime TanggalSidang { get; set; }
        public string TempatSidang { get; set; } = null!;
        public string WaktuSidang { get; set; } = null!;
        public string Penguji1 { get; set; } = null!;
        public string Penguji2 { get; set; } = null!;
        public string Penguji3 { get; set; } = null!;
        public string Pembimbing1 { get; set; } = null!;
        public string Pembimbing2 { get; private set; } = null!;

    }
}
