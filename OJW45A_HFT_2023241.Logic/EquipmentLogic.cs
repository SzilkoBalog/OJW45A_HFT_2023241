using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OJW45A_HFT_2023241.Logic
{
    public class EquipmentLogic : IEquipmentLogic
    {
        IRepository<Equipment> repository;

        public EquipmentLogic(IRepository<Equipment> repository)
        {
            this.repository = repository;
        }

        public void Create(Equipment item)
        {
            if (item.Type == null || item.Type.Length > 50 || item.Description?.Length > 200 || item.SoldierId == 0)//Checks if the values are eligible
            {
                throw new ArgumentException("Wrong type || type length || description length || soldierid");
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

        public Equipment Read(int id)
        {
            var equipment = repository.Read(id);
            if (equipment == null)//Checks if item exists
            {
                throw new ArgumentException("An item with this id does not exist");
            }
            return equipment;
        }

        public IEnumerable<Equipment> ReadAll()
        {
            return repository.ReadAll();//No check needed, if there is no data an empty IQueryable will be returned
        }

        public void Update(Equipment item)
        {
            repository.Update(item);//No need for checks, if item does not exist, there will be no changes done
        }
    }
}
