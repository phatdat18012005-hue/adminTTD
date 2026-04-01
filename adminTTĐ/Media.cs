public class Media
{
    public int Id { get; set; }
    public required string TenFile { get; set; }
    public required string DuongDan { get; set; }
    public required string Loai { get; set; }
    public DateTime NgayTaiLen { get; set; } = DateTime.Now;
    public int? BaiVietId { get; set; }
    public BaiViet? BaiViet { get; set; }
}
