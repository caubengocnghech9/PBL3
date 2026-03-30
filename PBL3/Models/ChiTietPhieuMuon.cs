using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class ChiTietPhieuMuon
{
    public int MaPm { get; set; }

    public int MaSach { get; set; }

    public string? TinhTrangSach { get; set; }

    public DateTime? NgayTra { get; set; }

    public decimal? TienPhat { get; set; }

    public virtual PhieuMuon MaPmNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
