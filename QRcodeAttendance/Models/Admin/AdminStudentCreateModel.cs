namespace QRcodeAttendance.Models.Admin
{
    public class AdminStudentCreateModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;

        public int SectionId { get; set; }
        public int SubjectId { get; set; }
        public bool AutoApprove { get; set; } = true;
    }
}   