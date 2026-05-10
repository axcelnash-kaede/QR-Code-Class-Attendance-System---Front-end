namespace QRcodeAttendance.Models
{
    public class TeacherSectionSubjectsDto
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; } = string.Empty;
        public List<TeacherSectionSubjectItemDto> Subjects { get; set; } = new();
    }

    public class TeacherSectionSubjectItemDto
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; } = string.Empty;
    }
}
