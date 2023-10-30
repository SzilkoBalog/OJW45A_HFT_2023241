using OJW45A_HFT_2023241.Repository;
using System;
using System.Linq;

namespace OJW45A_HFT_2023241.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            //"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TemporaryDb.mdf;Integrated Security=True;MultipleActiveResultSets = True"

            ArmyDbContext ctx = new ArmyDbContext();
            
            var items = ctx.Soldiers.ToArray();
            ;
        }
    }
}
