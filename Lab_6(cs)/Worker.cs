using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

internal class Worker : Human
{
    private decimal weekSalary;
    private int workHoursPerDay;
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }
    public int WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }
    public decimal SalaryPerHour()
    {
        return WeekSalary / (WorkHoursPerDay * 5);
    }
    public Worker(string name, string surname, decimal weekSalary, int workHoursPerDay) : base(name, surname)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }
    public override string ToString()
    {
        return $"First Name: {this.Name}\nLast Name: {this.Surname}\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.WorkHoursPerDay:F2}\nSalary per hour: {this.SalaryPerHour():F2}";
    }
}
