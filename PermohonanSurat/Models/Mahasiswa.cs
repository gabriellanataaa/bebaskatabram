using System;
using System.Collections.Generic;

namespace PermohonanSurat.Models;

public partial class Mahasiswa
{
    public int Nim { get; set; }

    public string NamaMahasiswa { get; set; } = null!;

    public string Alamat { get; set; } = null!;

    public string NomorTelepon { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Perusahaan { get; set; } = null!;

    public DateTime TanggalMagang { get; set; }

    public string AlamatMagang { get; set; } = null!;

    public string KotaMagang { get; set; } = null!;

}
