public class DanhMuc
{
    public int Id { get; set; }
    public required string TenDanhMuc { get; set; }
    public string? MoTa { get; set; }
    public List<BaiViet>? BaiViets { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
