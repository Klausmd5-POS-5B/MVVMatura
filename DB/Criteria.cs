namespace DB;

public class Criteria
{
    public int Id { get; set; }
    public int EvaluationType { get; set; } // 1 = Schule, 2 = Lehrer
    public string SequenceNr { get; set; }
    public string Description { get; set; }
    
    public List<EvaluationItem> EvaluationItems { get; set; }
}