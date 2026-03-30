using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? ChucVu { get; set; }

    public DateOnly? NgayVaoLam { get; set; }

    public decimal? Luong { get; set; }

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
