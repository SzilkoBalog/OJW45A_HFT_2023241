using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Repository
{
    public class ArmyBaseRepository : Repository<ArmyBase>, IRepository<ArmyBase>
    {
        public ArmyBaseRepository(ArmyDbContext ctx) : base(ctx)
        {
        }

        public override ArmyBase Read(int id)
        {
            return ctx.Bases.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(ArmyBase item)
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
