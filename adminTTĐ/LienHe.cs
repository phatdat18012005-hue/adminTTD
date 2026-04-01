public class LienHe
{
    public int Id { get; set; }
    public required string Ten { get; set; }
    public string? Email { get; set; }
    public string? SoDienThoai { get; set; }
    public required string NoiDung { get; set; }
    public string TrangThai { get; set; } = "Chua xu ly";
}
