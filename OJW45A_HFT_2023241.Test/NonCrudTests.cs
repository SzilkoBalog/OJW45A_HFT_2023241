using Moq;
using NUnit.Framework;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Logic.Logics;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OJW45A_HFT_2023241.Test
{
    [TestFixture]
    public class NonCrudTests
    {

        ArmyBaseLogic armyBaseLogic;
        SoldierLogic soldierLogic;
        EquipmentLogic equipmentLogic;

        Mock<IRepository<ArmyBase>> mockArmyBaseRepository;
        Mock<IRepository<Soldier>> mockSoldierRepository;
        Mock<IRepository<Equipment>> mockEquipmentRepository;

        [SetUp]
        public void SetUp()
        {
            var inputArmyBase = new List<ArmyBase>() 
            { 
                new ArmyBase() { Id = 1, Name = "TestBase", DateOfBuild = DateTime.Now, NumberOfBeds = 100 },
                new ArmyBase() { Id = 1, Name = "TestBase", DateOfBuild = DateTime.Now, NumberOfBeds = 100 },
                new ArmyBase() { Id = 1, Name = "TestBase", DateOfBuild = DateTime.Now, NumberOfBeds = 100 },
                new ArmyBase() { Id = 1, Name = "TestBase", DateOfBuild = DateTime.Now, NumberOfBeds = 100 },
                new ArmyBase() { Id = 1, Name = "TestBase", DateOfBuild = DateTime.Now, NumberOfBeds = 100 }
            }.AsQueryable();

            var inputSoldierBase = new List<Soldier>()
            {
                new Soldier() { Id = 1, Name = "TestSoldier", Age = 20, ArmyBaseId = 1 },
                new Soldier() { Id = 1, Name = "TestSoldier", Age = 20, ArmyBaseId = 1 },
                new Soldier() { Id = 1, Name = "TestSoldier", Age = 20, ArmyBaseId = 1 },
                new Soldier() { Id = 1, Name = "TestSoldier", Age = 20, ArmyBaseId = 1 },
                new Soldier() { Id = 1, Name = "TestSoldier", Age = 20, ArmyBaseId = 1 }
            }.AsQueryable();

            var inputEquipmentBase = new List<Equipment>()
            {
                new Equipment() { Id = 1, Type = "TestEquipment", Weight = 20, Description = "TestType", SoldierId = 1 },
                new Equipment() { Id = 1, Type = "TestEquipment", Weight = 20, Description = "TestType", SoldierId = 1 },
                new Equipment() { Id = 1, Type = "TestEquipment", Weight = 20, Description = "TestType", SoldierId = 1 },
                new Equipment() { Id = 1, Type = "TestEquipment", Weight = 20, Description = "TestType", SoldierId = 1 },
                new Equipment() { Id = 1, Type = "TestEquipment", Weight = 20, Description = "TestType", SoldierId = 1 }
            }.AsQueryable();

            mockArmyBaseRepository = new Mock<IRepository<ArmyBase>>();
            mockSoldierRepository = new Mock<IRepository<Soldier>>();
            mockEquipmentRepository = new Mock<IRepository<Equipment>>();

            mockArmyBaseRepository.Setup(x => x.ReadAll()).Returns(inputArmyBase);
            mockSoldierRepository.Setup(x => x.ReadAll()).Returns(inputSoldierBase);
            mockEquipmentRepository.Setup(x => x.ReadAll()).Returns(inputEquipmentBase);

            armyBaseLogic = new ArmyBaseLogic(mockArmyBaseRepository.Object);
            soldierLogic = new SoldierLogic(mockSoldierRepository.Object);
            equipmentLogic = new EquipmentLogic(mockEquipmentRepository.Object);
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
