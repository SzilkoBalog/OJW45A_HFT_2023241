using Microsoft.EntityFrameworkCore;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OJW45A_HFT_2023241.Logic.Logics
{
    public class SoldierLogic : ISoldierLogic
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

        public IEnumerable<Soldier> ReadAll()
        {
            return repository.ReadAll();//No check needed, if there is no data an empty IQueryable will be returned
        }

        public void Update(Soldier item)
        {
            repository.Update(item);//No need for checks, if item does not exist, there will be no changes done
        }

        public IEnumerable<KeyValuePair<Soldier, IEnumerable<string>>> GetSoldiersWithEquipmentTypes()
        {
            return repository.ReadAll()
                .Select(s => new KeyValuePair<Soldier, IEnumerable<string>>
                (s, s.Equipment.Select(e => e.Type)));
        }

        public IEnumerable<KeyValuePair<Soldier, int>> GetSoldiersWithTotalEquipmentWeight()
        {
            return repository.ReadAll()
                .Select(s => new KeyValuePair<Soldier, int>
                (s, s.Equipment.Sum(e => e.Weight)));
        }
    }
}
