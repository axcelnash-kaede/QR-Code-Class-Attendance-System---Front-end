namespace QRcodeAttendance.Models
{
    public class PendingStudentDto
    {
        public int Id { get; set; }
        public string? StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public string ApprovalStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}