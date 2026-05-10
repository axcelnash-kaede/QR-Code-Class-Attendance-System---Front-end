namespace QRcodeAttendance.Models.Admin
{
    public class AdminTeacherCreateModel
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public int SectionId { get; set; }
        public int SubjectId { get; set; }
    }
}