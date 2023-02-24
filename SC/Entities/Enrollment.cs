namespace SC.Entities;

public class Enrollment
{
    public uint Id { get; set; }

    public int StudentId { get; set; }

    public uint CourseId { get; set; }

    public int StudentNumber {  get; set; }

    public Student Student { get; set; }
    
    public Course Course { get; set; }
}
