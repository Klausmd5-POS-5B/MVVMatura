namespace DB;

public class Evaluation
{
    public int Id { get; set; }
    public int SchoolOrTeacherId { get; set; }
    public int EvaluationType { get; set; } // 1 = Schule, 2 = Lehrer
    public string PhoneNr { get; set; }
    
    public List<EvaluationItem> EvaluationItems { get; set; }
}