using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections;
using System.Linq;

namespace OJW45A_HFT_2023241.Logic
{
    public class ArmyBaseLogic
    {

        IRepository<ArmyBase> repository;

        public ArmyBaseLogic(IRepository<ArmyBase> repository)
        {
            this.repository = repository;
        }

        public void Create(ArmyBase item)
        {
            if (item.Name == null || item.Name.Length>50 || item.DateOfBuild ==0 || item.NumberOfBeds == 0)//Checks if the values are eligible
            {
                throw new ArgumentException("Wrong name || name length || dateofbuild || numberofbeds");
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

        public ArmyBase Read(int id)
        {
            var armybase = repository.Read(id);
            if (armybase == null)//Checks if item exists
            {
                throw new ArgumentException("An item with this id does not exist");
            }
            return armybase;
        }

        public IQueryable<ArmyBase> ReadAll()
        {
            return repository.ReadAll();//No check needed, if there is no data an empty IQueryable will be returned
        }

        public void Update(ArmyBase item)
        {
            repository.Update(item);//No need for checks, if item does not exist, there will be no changes done
        }

        public IEnumerable LogicMetodus1(ArmyBase item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus2(ArmyBase item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus3(ArmyBase item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus4(ArmyBase item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable LogicMetodus5(ArmyBase item)
        {
            throw new NotImplementedException();
        }
    }
}
