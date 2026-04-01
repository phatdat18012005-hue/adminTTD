public class BinhLuan
{
    public int Id { get; set; }
    public required string NoiDung { get; set; }
    public required string TenNguoiDung { get; set; }
    public DateTime NgayTao { get; set; } = DateTime.Now;
    public int BaiVietId { get; set; }
    public BaiViet? BaiViet { get; set; }
}
