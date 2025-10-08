using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public interface ISoldier
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
    }
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
    public interface ILeutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
   internal interface IEngineer : ISpecialisedSoldier
    {
       IReadOnlyCollection<Repair> Repairs { get; }
    }
    internal interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
