public class AuditLog
{
    public int Id { get; set; }
    public required string HanhDong { get; set; }
    public required string NguoiThucHien { get; set; }
    public DateTime ThoiGian { get; set; } = DateTime.Now;
    public string? MoTa { get; set; }
}
