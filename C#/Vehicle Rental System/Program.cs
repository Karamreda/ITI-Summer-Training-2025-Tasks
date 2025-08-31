using System;


public enum FuelType
{
    Petrol = 1,
    Diesel = 2,
    Electric = 3
}

public interface IRentable
{
    double CalculateRentalFee();
    void DisplayDetails(string customerName, string nationalId);
}

abstract class Vehicle : IRentable
{
    public string PlateNumber { get; set; }
    public int RentalDays { get; set; }
    public FuelType FuelType { get; set; }
    public double DailyRate { get; set; }

    public Vehicle(string plateNumber, int rentalDays, FuelType fuelType, double dailyRate)
    {
        PlateNumber = plateNumber;
        RentalDays = rentalDays;
        FuelType = fuelType;
        DailyRate = dailyRate;
    }

    public abstract string VehicleType();
    public abstract double CalculateRentalFee();

    public virtual void DisplayDetails(string customerName, string nationalId)
    {
        Console.WriteLine($"\nCustomer Name: {customerName}");
        Console.WriteLine($"National ID: {nationalId}");
        Console.WriteLine($"Vehicle Type: {VehicleType()}");
        Console.WriteLine($"Plate Number: {PlateNumber}");
        Console.WriteLine($"Fuel Type: {FuelType}");
        Console.WriteLine($"Rental Days: {RentalDays}");
        Console.WriteLine($"Daily Rate: {DailyRate} EGP");
        Console.WriteLine($"Total Rental Fee: {CalculateRentalFee()} EGP");
    }
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Car : Vehicle
{
    public bool InsuranceIncluded { get; set; }
    private const double InsuranceFeePerDay = 100;

    public Car(string plate, int days, FuelType fuel, double dailyRate, bool insurance)
        : base(plate, days, fuel, dailyRate)
    {
        InsuranceIncluded = insurance;
    }

    public override string VehicleType() => "Car";

    public override double CalculateRentalFee()
    {
        double insuranceFee = InsuranceIncluded ? InsuranceFeePerDay * RentalDays : 0;
        return (DailyRate * RentalDays) + insuranceFee;
    }

    public override void DisplayDetails(string customerName, string nationalId)
    {
        base.DisplayDetails(customerName, nationalId);
        Console.WriteLine($"Insurance Included: {(InsuranceIncluded ? "Yes" : "No")}");
        if (InsuranceIncluded)
            Console.WriteLine($"Insurance Fee: {InsuranceFeePerDay}/day");
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Truck : Vehicle
{
    public double WeightCharge { get; set; }

    public Truck(string plate, int days, FuelType fuel, double dailyRate, double weightCharge)
        : base(plate, days, fuel, dailyRate)
    {
        WeightCharge = weightCharge;
    }

    public override string VehicleType() => "Truck";

    public override double CalculateRentalFee()
    {
        return (DailyRate * RentalDays) + WeightCharge;
    }

    public override void DisplayDetails(string customerName, string nationalId)
    {
        base.DisplayDetails(customerName, nationalId);
        Console.WriteLine($"Weight Charge: {WeightCharge} EGP");
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Motorcycle : Vehicle
{
    public double HelmetFee { get; set; }

    public Motorcycle(string plate, int days, FuelType fuel, double dailyRate, double helmetFee)
        : base(plate, days, fuel, dailyRate)
    {
        HelmetFee = helmetFee;
    }

    public override string VehicleType() => "Motorcycle";

    public override double CalculateRentalFee()
    {
        return (DailyRate * RentalDays) + HelmetFee;
    }

    public override void DisplayDetails(string customerName, string nationalId)
    {
        base.DisplayDetails(customerName, nationalId);
        Console.WriteLine($"Helmet Fee: {HelmetFee} EGP");
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
class Program
{
    static void Main()
    {
        Console.Write("Please enter your name: ");
        string customerName = Console.ReadLine();

        Console.Write("Enter your National ID: ");
        string nationalId = Console.ReadLine();

        Console.WriteLine("\n Choose a Vehicle Type to Rent:");
        Console.WriteLine("1. Car");
        Console.WriteLine("2. Truck");
        Console.WriteLine("3. Motorcycle");
        Console.Write("Enter your choice: ");
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1-3");
        }
        /////////////////////////////////////////////////////////////
        Console.Write("Enter plate number: ");
        string plate = Console.ReadLine();

        Console.Write("Enter rental days: ");
        /////////////////////////////////////////////////////////////
        int days;
        while (!int.TryParse(Console.ReadLine(), out days) || days <= 0)
        {
            Console.WriteLine("Invalid, enter positive number:");
        }
        /////////////////////////////////////////////////////////////

        Console.Write("Enter Daily Rate: ");
        double dailyRate;
        while (!double.TryParse(Console.ReadLine(), out dailyRate) || dailyRate <= 0)
        {
            Console.WriteLine("Invalid, enter positive number:");
        }
        /////////////////////////////////////////////////////////////
        Console.WriteLine("\nSelect Fuel Type:");
        Console.WriteLine("1. Petrol");
        Console.WriteLine("2. Diesel");
        Console.WriteLine("3. Electric");
        Console.Write("Enter your choice: ");
        int fuelChoice;
        while (!int.TryParse(Console.ReadLine(), out fuelChoice) || fuelChoice < 0 || fuelChoice > 2)
        {
            Console.WriteLine("Invalid choice. Please enter a number between 1-3");
        }
        FuelType fuel = (FuelType)fuelChoice;

        Vehicle rentedVehicle = null;

        switch (choice)
        {
            case 1:
                Console.Write("Do you want to add insurance?(y/n): ");
                bool insurance = Console.ReadLine().ToLower() == "y";
                rentedVehicle = new Car(plate, days, fuel, dailyRate, insurance);
                break;

            case 2:
                Console.Write("Enter Weight Charge: ");
                double weightCharge = double.Parse(Console.ReadLine());
                rentedVehicle = new Truck(plate, days, fuel, dailyRate, weightCharge);
                break;

            case 3:
                Console.Write("Enter Helmet Fee: ");
                double helmetFee = double.Parse(Console.ReadLine());
                rentedVehicle = new Motorcycle(plate, days, fuel, dailyRate, helmetFee);
                break;
        }

        rentedVehicle.DisplayDetails(customerName, nationalId);
        Console.WriteLine("\nRental successfully recorded!");
    }
}