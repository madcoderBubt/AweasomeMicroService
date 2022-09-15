namespace StudentService.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime TakenDate { get; set; }
        public bool IsCompleted { get; set; }

    }
}