using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PermohonanSurat.Models;

public partial class PermohonanSuratContext : DbContext
{
    public PermohonanSuratContext()
    {
    }

    public PermohonanSuratContext(DbContextOptions<PermohonanSuratContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Perusahaan> Perusahaans { get; set; }

    public virtual DbSet<Mahasiswa> Mahasiswas { get; set; }

    public virtual DbSet<ReportNilai> ReportNilais { get; set; }

    public virtual DbSet<SuratSidangTugasAkhir> SidangTugasAkhirs { get; set; }

    public virtual DbSet<JadwalSidang> JadwalSidangs { get; set; }
    public object Mahasiswa { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mahasiswa>(entity =>
        {
            entity.HasKey(e => e.Nim);

            entity.ToTable("Mahasiswa");

            entity.Property(e => e.Nim).HasColumnName("NIM");
            entity.Property(e => e.Alamat)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.AlamatMagang)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.KotaMagang)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NamaMahasiswa)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NomorTelepon)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Perusahaan)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TanggalMagang).HasColumnType("date");
        });

        modelBuilder.Entity<Perusahaan>(entity =>
        {
            entity.HasKey(e => e.IdPerusahaan);

            entity.ToTable("Perusahaan");

            entity.Property(e => e.AlamatPerusahaan)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JumlahPerusahaan)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NamaPerusahaan)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReportNilai>(entity =>
        {
            entity.HasKey(e => e.IdReportNilai);

            entity.ToTable("ReportNilai");

            entity.Property(e => e.Catatan)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.DepartemenSeksiArea)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.KecepatanKerja)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.KreatifitasKerjasama)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.KualitasKerja)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NamaSiswa)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nim).HasColumnName("NIM");
            entity.Property(e => e.PengetahuanKerja)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.PeriodeBulan)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.RataRata)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SikapPerilaku)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SoftskillBeradaptasi)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SoftskillLeadership)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SoftskillMenanganiMasalah)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPerusahaanNavigation).WithMany(p => p.ReportNilais)
                .HasForeignKey(d => d.IdPerusahaan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportNilai_Perusahaan");

            entity.HasOne(d => d.NimNavigation).WithMany(p => p.ReportNilais)
                .HasForeignKey(d => d.Nim)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReportNilai_Perusahaan");
        });

        modelBuilder.Entity<SuratSidangTugasAkhir>(entity =>
        {
            entity.HasKey(e => e.IdSidang);

            entity.ToTable("SidangTugasAkhir");

            entity.Property(e => e.AlamatSidang)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Hrd)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("HRD");
            entity.Property(e => e.JudulTugasAkhir)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PembimbingAkademik)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PembimbingIndustri)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PembimbingIndustri1)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PembimbingIndustri2)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.PengujiPolman)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.TanggalSidang).HasColumnType("date");
            entity.Property(e => e.TempatSidang)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.WaktuSidang)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
