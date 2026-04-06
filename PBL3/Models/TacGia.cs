using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class TacGia
{
    public int MaTg { get; set; }

    public string TenTg { get; set; } = null!;

    public string? Website { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
