using System;
using System.Collections.Generic;

namespace PermohonanSurat.Models;

public partial class SuratSidangTugasAkhir
{
    public int IdSidang { get; set; }

    public string JudulTugasAkhir { get; set; } = null!;

    public DateTime TanggalSidang { get; set; }

    public string WaktuSidang { get; set; } = null!;

    public string TempatSidang { get; set; } = null!;

    public string AlamatSidang { get; set; } = null!;

    public string PembimbingAkademik { get; set; } = null!;

    public string PengujiPolman { get; set; } = null!;

    public string PembimbingIndustri { get; set; } = null!;

    public string PembimbingIndustri1 { get; set; } = null!;

    public string PembimbingIndustri2 { get; set; } = null!;

    public string Hrd { get; set; } = null!;
}
