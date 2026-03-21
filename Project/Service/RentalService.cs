namespace Project.Service;
using Project.Model;
public class RentalService
{
    private List<Rental> _rentals = new List<Rental>();
    
    private Inventory _inventory;
    private UserService _userService;

    public RentalService(Inventory inventory, UserService userService)
    {
        _inventory = inventory;
        _userService = userService;
    }

    public void RentItem(int userId, int equipmentId, int daysRented)
    {
        var user = _userService.GetUserById(userId);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var equipment = _inventory.GetItemById(equipmentId);
        if (equipment == null)
        {
            throw new Exception("Equipment not found");
        }

        if (!equipment.IsAvailable)
        {
            throw new Exception("Equipment is not available");
        }
        int currentRentals = CountActiveRentals(userId);
        if (currentRentals >= user.LimitRental)
        {
            throw new Exception("User has reached the limit of rentals");
        }
        var rental = new Rental(user, equipment, daysRented);
        _rentals.Add(rental);
        
        _inventory.MakeUnavailable(equipmentId);
    }

    private int CountActiveRentals(int userId)
    {
        int count = 0;
        foreach (var rental in _rentals)
        {
            if (rental.Rent.Id == userId && rental.ActualReturn == null)
            {
                count++;
            }
        }
        return count;
    }

    public void ReturnItem(int equipmentId)
    {
        Rental activeRental = null;
        foreach (var rental in _rentals)
        {
            if (rental.RentedItem.Id == equipmentId && rental.ActualReturn == null)
            {
                activeRental = rental;
                break;
            }
        }

        if (activeRental == null)
        {
            throw new Exception("Equipment is not rented");
        }
        activeRental.ActualReturn = DateTime.Now;
        if (!activeRental.IsReturnedOnTime)
        {
            int days = (activeRental.ActualReturn.Value - activeRental.DateReturn).Days;

            if (days == 0)
            {
                days = 1;
            }

            decimal penalty = 10m;
            activeRental.AdditionalFee = penalty * days;
        }
        else
        {
            activeRental.AdditionalFee = 0;
        }
        _inventory.MakeAvailable(equipmentId);
    }

    public void DisplayActiveRentals(int userId)
    {
        Console.WriteLine("Active rentals for user " + userId );
        bool found = false;
        foreach (var rental in _rentals)
        {
            if (rental.Rent.Id == userId && rental.ActualReturn == null)
            {
                Console.WriteLine($"Equipment: {rental.RentedItem.Name} , DateRent: {rental.DateRent} , DateReturn: {rental.DateReturn}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No active rentals");
        }
    }

    public void DisplayLateRentals()
    {
        Console.WriteLine("Late rentals");
        bool found = false;
        foreach (var rental in _rentals)
        {
            if (rental.ActualReturn == null && DateTime.Now > rental.DateReturn)
            {
                int lateDays = (DateTime.Now - rental.DateReturn).Days;
                Console.WriteLine(
                    $"Equipment: {rental.RentedItem.Name} , DateRent: {rental.DateRent} , DateReturn: {rental.DateReturn} , Late days: {lateDays}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No late rentals");
        }
    }

    public void GenerateReport()
    {
        Console.WriteLine("Generating report");
        int totalRentals = _rentals.Count;
        int activeRentals = 0;
        decimal feesCount = 0;
        
        foreach (var rental in _rentals)
        {
            if (rental.ActualReturn == null)
            {
                activeRentals++;
            }
            else
            {
                feesCount += rental.AdditionalFee; 
            }
        }
        Console.WriteLine($"Total rentals: {totalRentals} , Active rentals: {activeRentals} , Fees: {feesCount}");
    }
}