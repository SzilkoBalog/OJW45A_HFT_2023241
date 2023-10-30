using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Repository
{
    public class SoldierRepository : Repository<Soldier>, IRepository<Soldier>
    {
        public SoldierRepository(ArmyDbContext ctx) : base(ctx)
        {
        }

        public override Soldier Read(int id)
        {
            return ctx.Soldiers.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Soldier item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
