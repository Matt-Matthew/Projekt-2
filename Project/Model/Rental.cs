namespace Project.Model;

public class Rental
{
    private static int _nextId = 1;
    
    public int Id { get; private set; }
    public User Rent { get; private set; }
    public Equipment RentedItem { get; private set; }
    public DateTime DateRent { get; private set; }
    public DateTime DateReturn { get; private set; }
    public DateTime? ActualReturn { get; set; }

    public bool IsReturnedOnTime
    {
        get
        {
            if (ActualReturn == null)
            {
                return false;
            }
            return ActualReturn <= DateReturn;
        }
        
    }
    public decimal AdditionalFee { get; set; }

    public Rental(User rent, Equipment rentedItem, int daysRented)
    {
        Id = _nextId;
        _nextId++;
        
        Rent = rent;
        RentedItem = rentedItem;
        DateRent = DateTime.Now;
        DateReturn = DateRent.AddDays(daysRented);
    }

  
}