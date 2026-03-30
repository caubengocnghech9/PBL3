using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class DocGium
{
    public int MaDg { get; set; }

    public string HoTen { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public DateOnly? NgayLapThe { get; set; }

    public DateOnly? HanThe { get; set; }

    public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();

    public virtual TaiKhoanDocGium? TaiKhoanDocGium { get; set; }
}
