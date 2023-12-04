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

        public IEnumerable<GetBasesWithAverageSoldierAgeData> GetBasesWithAverageSoldierAge()
        {
            return repository.ReadAll()
                .Where(b => b.Soldiers.Count() > 0)
                .Select(b => new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = b.Name, 
                    AverageSoldierAge = b.Soldiers.Average(s => s.Age) 
                });
        }

        public IEnumerable<ArmyBaseData> GetArmyBaseStatistics()
        {
            return repository.ReadAll()
                .Where(b => b.Soldiers.Count() > 0)
                .Select(b => new ArmyBaseData
                {
                    BaseName = b.Name,
                    Count = b.Soldiers.Count(),
                    AvgWeight = (int)b.Soldiers.Average(s => s.Weight),
                    AvgAge = (int)b.Soldiers.Average(s => s.Age)
                });
        }

        public IEnumerable<GetEquipmentCountByTypePerBaseData> GetEquipmentCountByTypePerBase()
        {
            // Step 1: Get all bases from the repository
            var bases = repository.ReadAll();

            // Step 2: Project each base to a new anonymous type with base name and equipment
            var baseAndEquipment = bases.Select(b => new
            {
                BaseName = b.Name,
                Equipment = b.Soldiers.SelectMany(s => s.Equipment)
            });

            // Step 3: Flatten the structure to have one row per equipment type per base
            var flatResult = baseAndEquipment.SelectMany(be => be.Equipment, (be, e) => new
            {
                be.BaseName,
                EquipmentType = e.Type
            });

            // Step 4: Group by base name and equipment type, count occurrences
            var groupedResult = flatResult.GroupBy(x => new { x.BaseName, x.EquipmentType })
                                          .Select(g => new
                                          {
                                              g.Key.BaseName,
                                              g.Key.EquipmentType,
                                              EquipmentCount = g.Count()
                                          });

            // Step 5: Project the final result into the desired class
            return groupedResult.Select(g => new GetEquipmentCountByTypePerBaseData
            {
                BaseName = g.BaseName,
                EquipmentType = g.EquipmentType,
                EquipmentCount = g.EquipmentCount
            });
        }
    }
}
