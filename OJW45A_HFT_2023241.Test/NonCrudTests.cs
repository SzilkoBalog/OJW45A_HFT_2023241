using Moq;
using NUnit.Framework;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Logic.Logics;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;

namespace OJW45A_HFT_2023241.Test
{
    [TestFixture]
    public class NonCrudTests
    {

        IArmyBaseLogic armyBaseLogic;
        ISoldierLogic soldierLogic;
        IEquipmentLogic equipmentLogic;

        Mock<IRepository<ArmyBase>> mockArmyBaseRepository;
        Mock<IRepository<Soldier>> mockSoldierRepository;
        Mock<IRepository<Equipment>> mockEquipmentRepository;

        [SetUp]
        public void SetUp()
        {
            armyBaseLogic = new ArmyBaseLogic(new FakeArmyBaseRepository());
            soldierLogic = new SoldierLogic(new FakeSoldierRepository());
            equipmentLogic = new EquipmentLogic(new FakeEquipmentRepository());
        }

        //All non-crud tests

        [Test]
        public void GetBasesWithAverageSoldierAgeTest()
        {
            
            Assert.Pass();
        }

        [Test]
        public void GetEquipmentCountByTypePerBaseTest()
        {
            
            Assert.Pass();
        }

        [Test]
        public void GetArmyBaseStatisticsTest()
        {

            Assert.Pass();
        }

        [Test]
        public void GetSoldiersWithEquipmentTypesTest()
        {
            
            Assert.Pass();
        }

        [Test]
        public void GetSoldiersWithTotalEquipmentWeightTest()
        {
            
            Assert.Pass();
        }
    }
}
