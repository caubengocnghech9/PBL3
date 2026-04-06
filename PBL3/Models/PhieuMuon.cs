using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class PhieuMuon
{
    public int MaPm { get; set; }

    public int MaDg { get; set; }

    public int MaNv { get; set; }

    public DateTime? NgayMuon { get; set; }

    public DateTime NgayHetHan { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<ChiTietPhieuMuon>();

    public virtual DocGia MaDgNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
