namespace QRcodeAttendance.Models.Admin
{
    public class AdminStudentModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string StudentId { get; set; } = "";
        public int? SectionId { get; set; }
        public string? SectionName { get; set; }
        public string ApprovalStatus { get; set; } = "";
        public int? RequestedSubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? TeacherName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}