using Project.Model;

namespace Project.Service;

public class Inventory
{
    private List<Equipment> _equipmentList = new List<Equipment>();

    public void AddEquipment(Equipment equipment)
    {
        _equipmentList.Add(equipment);
    }
    public void DisplayInventory()
    {
        foreach (var equipment in _equipmentList)
        {
           Console.WriteLine($"Id: {equipment.Id} Name: {equipment.Name} , IsAvailable: {equipment.IsAvailable}");
        }
    }
    
    public void DisplayAvailableEquipment()
    {
        foreach (var equipment in _equipmentList)
        {
            if (equipment.IsAvailable)
            {
                Console.WriteLine($"Id: {equipment.Id} Name: {equipment.Name}");
            }
        }
    }

    public void MakeUnavailable(int equipmentId)
    {
        foreach (var euqipment in _equipmentList)
        {
            if (euqipment.Id == equipmentId)
            {
                euqipment.IsAvailable = false;
                break;
            }
        }
            
    }

    public Equipment GetItemById(int equipmentId)
    {
        foreach (var equipment in _equipmentList)
        {
            if (equipmentId == equipment.Id)
            {
                return equipment;
            }
        }
        return null;
    }
    
}