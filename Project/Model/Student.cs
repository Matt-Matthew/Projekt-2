namespace Project.Model;

public class Student : User
{
    public override int LimitRental => 2;
}