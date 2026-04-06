using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class TaiKhoanDocGia
{
    public int MaTk { get; set; }

    public int MaDg { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public decimal? SoDu { get; set; }

    public int? SoLuongMuonToiDa { get; set; }

    public bool? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }

    public virtual DocGia MaDgNavigation { get; set; } = null!;
}
