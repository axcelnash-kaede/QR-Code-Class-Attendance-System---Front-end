namespace QRcodeAttendance.Models.Admin
{
    public class AdminTeacherModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string StudentId { get; set; } = "";
        public string AssignedClasses { get; set; } = "";
        public string ApprovalStatus { get; set; } = "";
        public bool IsActive { get; set; } = true;
    }
}