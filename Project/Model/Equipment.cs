namespace Project.Model;

public abstract class Equipment
{
    private static int _nextId = 1;
    public int Id { get; set; }
    public String Name { get; set; }
    public bool IsAvailable { get; set; }
    
    public Equipment()
    {
        Id = _nextId;
        _nextId++;
    }
    
}