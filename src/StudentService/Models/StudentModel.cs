namespace StudentService.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public int BatchNo { get; set; }
        public int Section { get; set; }
        public string Department { get; set; }
        public string Phone { get; set; }
        public string FullName { get; set; }
        public BloodGroupEnum BloodGroup { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
    }
}
