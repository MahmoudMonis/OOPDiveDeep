using System;

public abstract class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee(int employeeId, string firstName, string lastName)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
    }

    public abstract void Work();

    public virtual void DisplayGreeting()
    {
        Console.WriteLine($"Hello, {FirstName} {LastName}!");
    }
}

public class FullTimeEmployee : Employee, ISalaryCalculator, IManager
{
    public double MonthlySalary { get; set; }

    public FullTimeEmployee(int employeeId, string firstName, string lastName, double monthlySalary)
        : base(employeeId, firstName, lastName)
    {
        MonthlySalary = monthlySalary;
    }

    public override void Work()
    {
        Console.WriteLine($"Full-time employee {FirstName} {LastName} is working.");
    }

    public double CalculateSalary()
    {
        return MonthlySalary;
    }

    public void AssignTasks()
    {
        Console.WriteLine($"Manager {FirstName} {LastName} is assigning tasks.");
    }
}

public class PartTimeEmployee : Employee, ISalaryCalculator
{
    public double HourlyRate { get; set; }

    public PartTimeEmployee(int employeeId, string firstName, string lastName, double hourlyRate)
        : base(employeeId, firstName, lastName)
    {
        HourlyRate = hourlyRate;
    }

    public override void Work()
    {
        Console.WriteLine($"Part-time employee {FirstName} {LastName} is Pew pew Pew.");
    }

    public double CalculateSalary()
    {
        return HourlyRate * 8 * 20;
    }
}

public interface ISalaryCalculator
{
    double CalculateSalary();
}

public interface IManager
{
    void AssignTasks();
}

public class Program
{
    public static void Main(string[] args)
    {
        FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(1, "Mahmoud", "Taha", 5000);
        PartTimeEmployee partTimeEmployee = new PartTimeEmployee(2, "Ahmad", "Mohsin", 15);

        // Polymorphism
        Employee employee1 = fullTimeEmployee;
        Employee employee2 = partTimeEmployee;

        // Encapsulation and abstraction
        employee1.DisplayGreeting();
        employee2.DisplayGreeting();

        // Inheritance and polymorphism
        employee1.Work();
        employee2.Work();

        // Interface implementation
        ISalaryCalculator salaryCalculator = fullTimeEmployee;

        Console.WriteLine($"Full-time employee salary: {salaryCalculator.CalculateSalary()}");

        if (employee1 is IManager)
        {
            IManager manager = (IManager)employee1;
            manager.AssignTasks();
        }
    }
}
