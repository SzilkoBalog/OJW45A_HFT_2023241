using OJW45A_HFT_2023241.Logic;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Linq;
using System.Xml.Linq;

namespace OJW45A_HFT_2023241.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ctx = new ArmyDbContext();
            var repo = new ArmyBaseRepository(ctx);
            var test = new ArmyBaseLogic(repo);

            var all = test.ReadAll();
            var id6 = test.Read(6);
            test.Delete(6);
            try
            {
                var idrossz = test.Read(6);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                test.Create(new ArmyBase {Name = "Base Alpha", NumberOfBeds = 100, DateOfBuild = new DateTime(2002, 10, 10) });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                test.Create(new ArmyBase { Id = 1, Name = "Base Alpha", DateOfBuild = new DateTime(2002, 10, 10) });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                test.Create(new ArmyBase { Id = 1, Name = "Base Alpha", NumberOfBeds = 100});
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            ;
        }
    }
}
