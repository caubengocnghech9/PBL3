using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class NhaXuatBan
{
    public int MaNxb { get; set; }

    public string TenNxb { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
