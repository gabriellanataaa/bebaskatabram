using System;
using System.Collections.Generic;

namespace PermohonanSurat.Models;

public partial class ReportNilai
{
    public int IdReportNilai { get; set; }

    public int Nim { get; set; }

    public string NamaSiswa { get; set; } = null!;

    public int IdPerusahaan { get; set; }

    public string DepartemenSeksiArea { get; set; } = null!;

    public string PeriodeBulan { get; set; } = null!;

    public string PengetahuanKerja { get; set; } = null!;

    public string KualitasKerja { get; set; } = null!;

    public string KecepatanKerja { get; set; } = null!;

    public string SikapPerilaku { get; set; } = null!;

    public string KreatifitasKerjasama { get; set; } = null!;

    public string SoftskillLeadership { get; set; } = null!;

    public string SoftskillMenanganiMasalah { get; set; } = null!;

    public string SoftskillBeradaptasi { get; set; } = null!;

    public string RataRata { get; set; } = null!;

    public string Catatan { get; set; } = null!;

    public virtual Perusahaan IdPerusahaanNavigation { get; set; } = null!;

    public virtual Perusahaan NimNavigation { get; set; } = null!;
}
