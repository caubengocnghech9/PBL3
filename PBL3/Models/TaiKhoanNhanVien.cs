using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class TaiKhoanNhanVien
{
    public int MaTk { get; set; }

    public int? MaNv { get; set; }

    public string TenDangNhap { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? TrangThai { get; set; }

    public DateTime? NgayTao { get; set; }
}
