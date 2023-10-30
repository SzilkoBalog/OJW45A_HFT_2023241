using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Linq;

namespace OJW45A_HFT_2023241.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Soldier> repo1 = new SoldierRepository(new ArmyDbContext ());
            
            var items = repo1.ReadAll().ToArray();
            ;
        }
    }
}
