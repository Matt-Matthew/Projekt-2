namespace Project.Model;

public abstract class User
{
    private static int _nextId = 1;
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string LastName { get; set; }
    
    public User()
    {
        Id = _nextId;
        _nextId++;
    }
    public abstract int LimitRental { get; } 
}