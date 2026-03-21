using Project.Model;
using Project.Service;

Inventory inventory = new Inventory();
UserService userService = new UserService();
RentalService rentalService = new RentalService(inventory, userService);

var laptop = new Laptop{Name = "ThinkPad",RamSize = 16,StorageSize = 1024,IsAvailable = true};
var camera = new Camera {Name = "Canon",Megapixels = "48",IsAvailable = true};
var projector = new Projector {Name = "Samsung",Resolution = "4K",IsAvailable = true};

inventory.AddEquipment(laptop);
inventory.AddEquipment(camera);
inventory.AddEquipment(projector);

var student = new Student() {Name = "Igor", LastName = "Janik" , Email = "igor@gmail.com"};
var employee = new Employee() {Name = "employ", LastName = "Some" , Email = "some@gmail.com"};

userService.AddUser(student);
userService.AddUser(employee);

Console.WriteLine("Rental Item");
rentalService.RentItem(student.Id, laptop.Id, 5);
rentalService.DisplayActiveRentals(student.Id);

Console.WriteLine("Incorrect rental");
try
{
    rentalService.RentItem(employee.Id, laptop.Id, 3);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

Console.WriteLine("Return item");
rentalService.ReturnItem(laptop.Id);

Console.WriteLine("Late return item");
rentalService.RentItem(employee.Id,camera.Id,-2);
rentalService.ReturnItem(camera.Id);

Console.WriteLine("Generate report");
rentalService.GenerateReport();
