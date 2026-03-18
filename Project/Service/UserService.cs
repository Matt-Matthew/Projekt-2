using Project.Model;

namespace Project.Service;
using Project.Model;
public class UserService
{
    private List<User> _users = new List<User>();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void DisplayUsers()
    {
        foreach (var user in _users)
        {
            Console.WriteLine($"Id: {user.Id} Name: {user.Name} , LastName {user.LastName} ,Email: {user.Email}");
        }
    }
    
    public User GetUserById(int userId)
    {
        foreach (var user in _users)
        {
            if (userId == user.Id)
            {
                return user;
            }
        }
        return null;
    }
}