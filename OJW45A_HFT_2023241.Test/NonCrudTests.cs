using Moq;
using NUnit.Framework;
using OJW45A_HFT_2023241.Logic.Logics;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using static OJW45A_HFT_2023241.Logic.Logics.ArmyBaseLogic;

namespace OJW45A_HFT_2023241.Test
{
    [TestFixture]
    public class NonCrudTests
    {
        ArmyBaseLogic armyBaseLogic;
        SoldierLogic soldierLogic;

        Mock<IRepository<ArmyBase>> mockArmyBaseRepository;
        Mock<IRepository<Soldier>> mockSoldierRepository;

        IQueryable<ArmyBase> inputArmyBase;
        IQueryable<Soldier> inputSoldier;

        [SetUp]
        public void SetUp()
        {
            inputArmyBase = new List<ArmyBase>()
            {
                new ArmyBase() { Id = 1, Name = "TestBase1", DateOfBuild = DateTime.Now, NumberOfBeds = 100, Soldiers = new List<Soldier>
                {
                    new Soldier { Age = 28, Weight = 85, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType1", Weight = 10 },
                        new Equipment { Type = "TestType1", Weight = 20 },
                        new Equipment { Type = "TestType1", Weight = 30 }
                    } },
                    new Soldier { Age = 35, Weight = 95, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType1", Weight = 10 },
                        new Equipment { Type = "TestType1", Weight = 20 },
                        new Equipment { Type = "TestType1", Weight = 30 }
                    } }
                }  },
                new ArmyBase() { Id = 2, Name = "TestBase2", DateOfBuild = DateTime.Now, NumberOfBeds = 100, Soldiers = new List<Soldier>
                {
                    new Soldier { Age = 18, Weight = 100, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType1", Weight = 10 },
                        new Equipment { Type = "TestType2", Weight = 20 },
                        new Equipment { Type = "TestType3", Weight = 30 }
                    } },
                    new Soldier { Age = 42, Weight = 100, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType1", Weight = 10 },
                        new Equipment { Type = "TestType2", Weight = 20 },
                        new Equipment { Type = "TestType3", Weight = 30 }
                    } }
                }  },
                new ArmyBase() { Id = 3, Name = "TestBase3", DateOfBuild = DateTime.Now, NumberOfBeds = 100, Soldiers = new List<Soldier>
                {
                    new Soldier { Age = 50, Weight = 65, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType1", Weight = 10 },
                        new Equipment { Type = "TestType1", Weight = 20 },
                        new Equipment { Type = "TestType1", Weight = 30 }
                    } },
                    new Soldier { Age = 50, Weight = 60, Equipment = new List<Equipment>
                    {
                        new Equipment { Type = "TestType2", Weight = 10 },
                        new Equipment { Type = "TestType2", Weight = 20 },
                        new Equipment { Type = "TestType2", Weight = 30 }
                    } }
                }  },
                new ArmyBase() { Id = 4, Name = "TestBase4", DateOfBuild = DateTime.Now, NumberOfBeds = 100, Soldiers = new List<Soldier>
                {
                    new Soldier { Age = 0, Weight = 120 },
                    new Soldier { Age = 0, Weight = 120 }
                }  },
                new ArmyBase() { Id = 5, Name = "TestBase5", DateOfBuild = DateTime.Now, NumberOfBeds = 100, Soldiers = new List<Soldier>
                {
                    new Soldier { Age = 0, Weight = 0 },
                    new Soldier { Age = 100 , Weight = 0}
                }  },
            }.AsQueryable();

            inputSoldier = new List<Soldier>()
            {
                new Soldier {Id = 1, Age = 28, Weight = 85, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 10 },
                    new Equipment { Type = "TestType1", Weight = 20 },
                    new Equipment { Type = "TestType1", Weight = 30 }
                } },
                new Soldier {Id = 2, Age = 35, Weight = 95, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 10 },
                    new Equipment { Type = "TestType1", Weight = 20 },
                    new Equipment { Type = "TestType1", Weight = 30 }
                } },
                new Soldier {Id = 3, Age = 18, Weight = 100, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 10 },
                    new Equipment { Type = "TestType2", Weight = 20 },
                    new Equipment { Type = "TestType3", Weight = 30 }
                } },
                new Soldier {Id = 4, Age = 42, Weight = 100, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 10 },
                    new Equipment { Type = "TestType2", Weight = 20 },
                    new Equipment { Type = "TestType3", Weight = 30 }
                } },
                new Soldier {Id = 5, Age = 50, Weight = 65, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 10 },
                    new Equipment { Type = "TestType1", Weight = 20 },
                    new Equipment { Type = "TestType1", Weight = 30 }
                } }
            }.AsQueryable();

            mockArmyBaseRepository = new Mock<IRepository<ArmyBase>>();
            mockSoldierRepository = new Mock<IRepository<Soldier>>();

            armyBaseLogic = new ArmyBaseLogic(mockArmyBaseRepository.Object);
            soldierLogic = new SoldierLogic(mockSoldierRepository.Object);

            mockArmyBaseRepository.Setup(x => x.ReadAll()).Returns(inputArmyBase);
            mockSoldierRepository.Setup(x => x.ReadAll()).Returns(inputSoldier);
        }

        //All non-crud tests

        [Test]
        public void GetBasesWithAverageSoldierAgeTest()
        {
            // Act
            var result = armyBaseLogic.GetBasesWithAverageSoldierAge();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(inputArmyBase.Count(), result.Count());

            foreach (var kvp in result)
            {
                var expectedAverageAge = kvp.Key.Soldiers.Average(s => s.Age);
                Assert.AreEqual(expectedAverageAge, kvp.Value);
            }
        }

        [Test]
        public void GetArmyBaseStatisticsTest()
        {
            // Act
            var result = armyBaseLogic.GetArmyBaseStatistics();

            // Assert
            Assert.IsNotNull(result);

            var expectedResult = new List<ArmyBaseData>
        {
            new ArmyBaseData
            {
                BaseName = "TestBase1",
                Count = 2,
                AvgWeight = 90,
                AvgAge = 31
            },
            new ArmyBaseData
            {
                BaseName = "TestBase2",
                Count = 2,
                AvgWeight = 100,
                AvgAge = 30
            },
            new ArmyBaseData
            {
                BaseName = "TestBase3",
                Count = 2,
                AvgWeight = 62,
                AvgAge = 50
            },
            new ArmyBaseData
            {
                BaseName = "TestBase4",
                Count = 2,
                AvgWeight = 120,
                AvgAge = 0
            },
            new ArmyBaseData
            {
                BaseName = "TestBase5",
                Count = 2,
                AvgWeight = 0,
                AvgAge = 50
            }
        };

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void GetEquipmentCountByTypePerBaseTest()
        {
            //Act
            var result = armyBaseLogic.GetEquipmentCountByTypePerBase();

            // Assert
            Assert.IsNotNull(result);

            var expectedResult = new List<KeyValuePair<string, Dictionary<string, int>>>
        {
            new KeyValuePair<string, Dictionary<string, int>>("BaseId:1", new Dictionary<string, int>
            {
                { "TestType1", 6 }, // Expected counts for TestBase1
            }),
            new KeyValuePair<string, Dictionary<string, int>>("BaseId:2", new Dictionary<string, int>
            {
                { "TestType1", 2 },
                { "TestType2", 2 },
                { "TestType3", 2 }// Expected counts for TestBase2
            }),
            new KeyValuePair<string, Dictionary<string, int>>("BaseId:3", new Dictionary<string, int>
            {
                { "TestType1", 3 },
                { "TestType2", 3 },// Expected counts for TestBase3
            }),
            new KeyValuePair<string, Dictionary<string, int>>("BaseId:4", new Dictionary<string, int>{}),
            new KeyValuePair<string, Dictionary<string, int>>("BaseId:5", new Dictionary<string, int>{})
        };

            CollectionAssert.AreEquivalent(expectedResult, result);
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
