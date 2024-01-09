using System;
using System.Collections.Generic;

namespace PermohonanSurat.Models;

public partial class Perusahaan
{
    public int IdPerusahaan { get; set; }

    public string NamaPerusahaan { get; set; } = null!;

    public string AlamatPerusahaan { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string JumlahPerusahaan { get; set; } = null!;

    public virtual ICollection<ReportNilai> ReportNilais { get; set; } = new List<ReportNilai>();
}
