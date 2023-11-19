using OJW45A_HFT_2023241.Models;
using System.Collections.Generic;

namespace OJW45A_HFT_2023241.Logic.LogicInterfaces
{
    public interface IEquipmentLogic
    {
        void Create(Equipment item);
        void Delete(int id);
        Equipment Read(int id);
        IEnumerable<Equipment> ReadAll();
        void Update(Equipment item);
    }
}