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
    public class ArmyBaseLogic : IArmyBaseLogic
    {

        IRepository<ArmyBase> repository;

        public ArmyBaseLogic(IRepository<ArmyBase> repository)
        {
            this.repository = repository;
        }

        public void Create(ArmyBase item)
        {
            if (item.Name == null || item.Name.Length > 50 || item.DateOfBuild == DateTime.MinValue || item.NumberOfBeds == 0)//Checks if the values are eligible
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

        public IEnumerable<ArmyBase> ReadAll()
        {
            return repository.ReadAll();//No check needed, if there is no data an empty IQueryable will be returned
        }

        public void Update(ArmyBase item)
        {
            repository.Update(item);//No need for checks, if item does not exist, there will be no changes done
        }

        public IEnumerable<KeyValuePair<ArmyBase, double>> GetBasesWithAverageSoldierAge()
        {
            return repository.ReadAll().ToList()
                .Select(b => new KeyValuePair<ArmyBase, double>
                (b, b.Soldiers.Average(s => s.Age)))
                .ToList();
        }

        public IEnumerable<ArmyBaseData> GetArmyBaseStatistics()
        {
            return repository.ReadAll().ToList()
                .Select(b => new ArmyBaseData
                {
                    BaseName = b.Name,
                    Count = b.Soldiers.Count(),
                    AvgWeight = (int)b.Soldiers.Average(s => s.Weight),
                    AvgAge = (int)b.Soldiers.Average(s => s.Age)
                })
                .ToList();
        }

        public IEnumerable<KeyValuePair<string, Dictionary<string, int>>> GetEquipmentCountByTypePerBase()
        {
            return repository.ReadAll().ToList()
                .Select(b => new KeyValuePair<string, Dictionary<string, int>>(
                    $"BaseId:{b.Id}",
                    b.Soldiers
                        .SelectMany(s => s.Equipment)
                        .GroupBy(e => e.Type)
                        .ToDictionary(g => g.Key, g => g.Count())
                ))
                .ToList();
        }

        public class ArmyBaseData
        {
            public string BaseName { get; set; }
            public int Count { get; set; }
            public int AvgWeight { get; set; }
            public int AvgAge { get; set; }

            public override bool Equals(object obj)
            {
                return obj is ArmyBaseData data &&
                       BaseName == data.BaseName &&
                       Count == data.Count &&
                       AvgWeight == data.AvgWeight &&
                       AvgAge == data.AvgAge;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(BaseName, Count, AvgWeight, AvgAge);
            }
        }
    }
}
