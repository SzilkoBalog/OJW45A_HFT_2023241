using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Linq;

namespace OJW45A_HFT_2023241.Logic
{
    public class SoldierLogic
    {
        IRepository<Soldier> repository;

        public SoldierLogic(IRepository<Soldier> repository)
        {
            this.repository = repository;
        }

        public void Create(Soldier item)
        {
            if (item.Name == null || item.Name.Length > 50 || item.Age < 18 || item.ArmyBaseId == 0)//Checks if the values are eligible
            {
                throw new ArgumentException("Wrong name || name length || age || armybaseid");
            }
            repository.Create(item);
        }

        public void Delete(int id)
        {
            if (repository.Read(id) == null)//Checks if item exists before deleting
            {
                throw new ArgumentException("An item with this id does not exist");
            }
            repository.Delete(id);
        }

        public Soldier Read(int id)
        {
            var soldier = repository.Read(id);
            if (soldier == null)//Checks if item exists
            {
                throw new ArgumentException("An item with this id does not exist");
            }
            return soldier;
        }

        public IQueryable<Soldier> ReadAll()
        {
            return repository.ReadAll();//No check needed, if there is no data an empty IQueryable will be returned
        }

        public void Update(Soldier item)
        {
            repository.Update(item);//No need for checks, if item does not exist, there will be no changes done
        }

        public IEnumerable LogicMetodus1(Soldier item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus2(Soldier item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus3(Soldier item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus4(Soldier item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus5(Soldier item)
        {
            throw new NotImplementedException();
        }
    }
}
