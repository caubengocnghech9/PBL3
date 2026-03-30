using System;
using System.Collections.Generic;

namespace PBL3.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public int? MaTl { get; set; }

    public int? MaTg { get; set; }

    public int? MaNxb { get; set; }

    public int? NamXb { get; set; }

    public int? SoLuongTon { get; set; }

    public decimal? DonGia { get; set; }

    public string? TinhTrang { get; set; }

    public virtual ICollection<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; } = new List<ChiTietPhieuMuon>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NhaXuatBan? MaNxbNavigation { get; set; }

    public virtual TacGium? MaTgNavigation { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}
