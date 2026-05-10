namespace QRcodeAttendance.Models.Admin
{
    public class SubjectModel
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; } = "";

        public int SectionId { get; set; }

        public string? SectionName { get; set; }

        public int? TeacherId { get; set; }

        public string? TeacherName { get; set; }
    }

    public class CreateSubjectModel
    {
        public string Name { get; set; } = "";
    }
}