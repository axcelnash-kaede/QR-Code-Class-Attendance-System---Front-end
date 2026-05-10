namespace QRcodeAttendance.Models
{
    public class CreateSessionResponseDto
    {
        public int SessionId { get; set; }
        public string QrCode { get; set; } = string.Empty;
        public string QrToken { get; set; } = string.Empty;
    }
}
