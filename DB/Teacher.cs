namespace DB;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    
    public int SchoolId { get; set; }
    
    public School School { get; set; }
}