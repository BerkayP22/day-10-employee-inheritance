using System;

namespace Gün10
{
    public interface IWorkable
    {
        void Work();
    }
    public abstract class Company
    {
        public abstract int YearsWorked();
    }
    public class Employee : Company
    {
        private int salary;
        private string name;
        private decimal workHours;
        public override int YearsWorked()
        {
            return 5;
        }

        public virtual decimal CalculateTotalPay()
        {
            return Salary;
        }
        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Salary can't be negative.");
                }

                salary = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be null or empty.");
                }

                name = value;
            }
        }

        public decimal WorkHours
        {
            get
            {
                return workHours;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours can't be negative.");
                }

                workHours = value;
            }
        }

        public Employee(string name, int salary, decimal workHours)
        {
            Name = name;
            Salary = salary;
            WorkHours = workHours;
        }
    }

    public class Developer : Employee, IWorkable
    {
        public void Work()
        {
            Console.WriteLine("is working on Developer.");
        }
        private string programmingLanguage;

        public string ProgrammingLanguage
        {
            get
            {
                return programmingLanguage;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        "Programming language can't be null or empty."
                    );
                }

                programmingLanguage = value;
            }
        }
        public override decimal CalculateTotalPay()
        {
            return Salary + 5000;
        }
        public Developer(
            string name,
            int salary,
            decimal workHours,
            string programmingLanguage
        ) : base(name, salary, workHours)
        {
            ProgrammingLanguage = programmingLanguage;
        }
    }
  
    public class Manager : Employee, IWorkable
    {
        private int teamSize;
        
        public void Work()
        {
            Console.WriteLine("is working on Manager.");
        }
        public int TeamSize
        {
            get
            {
                return teamSize;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(
                        "Team size can't be negative."
                    );
                }

                teamSize = value;
            }
        }
        public override decimal CalculateTotalPay()
        {
            return Salary + 50000;
        }
        public Manager(
            string name,
            int salary,
            decimal workHours,
            int teamSize
        ) : base(name, salary, workHours)
        {
            TeamSize = teamSize;
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Developer developer =
                new Developer("Berkay", 50000, 45, "C#");

            Manager manager =
                new Manager("Berkay", 60000, 40, 10);

            Employee employee1 = new Developer("Berkay", 50000, 45, "C#");
            Employee employee2 = new Manager("Berkay", 60000, 40, 10);

            Console.WriteLine(employee1.CalculateTotalPay());
            Console.WriteLine(employee2.CalculateTotalPay());

            Console.WriteLine(
                $"Developer: {developer.Name}\n" +
                $"Salary: {developer.Salary}\n" +
                $"Work Hours: {developer.WorkHours}\n" +
                $"Programming Language: {developer.ProgrammingLanguage}\n" +
                $"Bonus: {developer.CalculateTotalPay()}"
            );

            Console.WriteLine();

            Console.WriteLine(
                $"Manager: {manager.Name}\n" +
                $"Salary: {manager.Salary}\n" +
                $"Work Hours: {manager.WorkHours}\n" +
                $"Team Size: {manager.TeamSize}\n" +
                $"Bonus: {manager.CalculateTotalPay()}"
            );

            Console.ReadLine();
        }
    }
}