using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class ChiTietPhieuNhap
{
    public int MaPn { get; set; }

    public int MaSach { get; set; }

    public int? SoLuongNhap { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public virtual PhieuNhap MaPnNavigation { get; set; } = null!;

    public virtual Sach MaSachNavigation { get; set; } = null!;
}
