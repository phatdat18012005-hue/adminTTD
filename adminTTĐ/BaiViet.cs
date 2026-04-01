public class BaiViet
{
    public int Id { get; set; }
    public string? TieuDe { get; set; }
    public string? NoiDung { get; set; }
    public int? DanhMucId { get; set; }
    public int? TacGiaId { get; set; }
    public string? TrangThai { get; set; }
    public DateTime NgayTao { get; set; }
    public List<BinhLuan>? BinhLuans { get; set; }
    public List<Media>? Medias { get; set; }
}
