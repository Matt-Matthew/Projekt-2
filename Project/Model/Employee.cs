namespace Project.Model;

public class Employee : User
{
    public override int LimitRental => 5;
}