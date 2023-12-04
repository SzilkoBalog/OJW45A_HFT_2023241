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
                    new Equipment { Type = "TestType2", Weight = 10 },
                    new Equipment { Type = "TestType3", Weight = 10 }
                } },
                new Soldier {Id = 3, Age = 18, Weight = 100, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 1 },
                    new Equipment { Type = "TestType2", Weight = 1 },
                    new Equipment { Type = "TestType1", Weight = 0 },
                } },
                new Soldier {Id = 4, Age = 42, Weight = 100, Equipment = new List<Equipment>
                {
                    new Equipment { Type = "TestType1", Weight = 5 },
                } },
                new Soldier {Id = 5, Age = 50, Weight = 65 }
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

            var expectedResult = new List<GetBasesWithAverageSoldierAgeData>
            {
                new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = "TestBase1",
                    AverageSoldierAge = 31
                },
                new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = "TestBase2",
                    AverageSoldierAge = 30
                },
                new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = "TestBase3",
                    AverageSoldierAge = 50
                },
                new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = "TestBase4",
                    AverageSoldierAge = 0
                },
                new GetBasesWithAverageSoldierAgeData
                {
                    BaseName = "TestBase5",
                    AverageSoldierAge = 50
                }
            };
        }

        [Test]
        public void GetArmyBaseStatisticsTest()
        {
            // Act
            var result = armyBaseLogic.GetArmyBaseStatistics();

            // Assert
            Assert.IsNotNull(result);

            var expectedResult = new List<GetArmyBaseStatisticsData>
        {
            new GetArmyBaseStatisticsData
            {
                BaseName = "TestBase1",
                Count = 2,
                AvgWeight = 90,
                AvgAge = 31
            },
            new GetArmyBaseStatisticsData
            {
                BaseName = "TestBase2",
                Count = 2,
                AvgWeight = 100,
                AvgAge = 30
            },
            new GetArmyBaseStatisticsData
            {
                BaseName = "TestBase3",
                Count = 2,
                AvgWeight = 62,
                AvgAge = 50
            },
            new GetArmyBaseStatisticsData
            {
                BaseName = "TestBase4",
                Count = 2,
                AvgWeight = 120,
                AvgAge = 0
            },
            new GetArmyBaseStatisticsData
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

            var expectedResult = new List<GetEquipmentCountByTypePerBaseData>
        {
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase1",
            EquipmentType = "TestType1",
            EquipmentCount = 6
            },
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase2",
            EquipmentType = "TestType1",
            EquipmentCount = 2
            },
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase2",
            EquipmentType = "TestType2",
            EquipmentCount = 2
            },
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase2",
            EquipmentType = "TestType3",
            EquipmentCount = 2
            },
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase3",
            EquipmentType = "TestType1",
            EquipmentCount = 3
            },
            new GetEquipmentCountByTypePerBaseData
            {
            BaseName = "TestBase3",
            EquipmentType = "TestType2",
            EquipmentCount = 3
            }
        };

            CollectionAssert.AreEquivalent(expectedResult, result);
        }


        [Test]
        public void GetSoldiersWithEquipmentTypesTest()
        {
            // Act
            var result = soldierLogic.GetSoldiersWithEquipmentTypes();

            // Assert
            Assert.IsNotNull(result);

            var expectedResult = new List<KeyValuePair<Soldier, IEnumerable<string>>>
        {
            new KeyValuePair<Soldier, IEnumerable<string>>(inputSoldier.First(), new List<string> { "TestType1", "TestType1", "TestType1" }),
            new KeyValuePair<Soldier, IEnumerable<string>>(inputSoldier.Skip(1).First(), new List<string> { "TestType1", "TestType2", "TestType3" }),
            new KeyValuePair<Soldier, IEnumerable<string>>(inputSoldier.Skip(2).First(), new List<string> { "TestType1", "TestType2", "TestType1" }),
            new KeyValuePair<Soldier, IEnumerable<string>>(inputSoldier.Skip(3).First(), new List<string> { "TestType1" }),
            new KeyValuePair<Soldier, IEnumerable<string>>(inputSoldier.Skip(4).First(), new List<string> {})
        };

            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [Test]
        public void GetSoldiersWithTotalEquipmentWeightTest()
        {
            // Act
            var result = soldierLogic.GetSoldiersWithTotalEquipmentWeight();

            // Assert
            Assert.IsNotNull(result);

            var expectedResult = new List<GetSoldiersWithTotalEquipmentWeightData>
        {
                new GetSoldiersWithTotalEquipmentWeightData
                {
                    soldier = inputSoldier.First(),
                    TotalEquipmentWeight = 60                
                },
                new GetSoldiersWithTotalEquipmentWeightData
                {
                    soldier = inputSoldier.Skip(1).First(),
                    TotalEquipmentWeight = 30
                },
                new GetSoldiersWithTotalEquipmentWeightData
                {
                    soldier = inputSoldier.Skip(2).First(),
                    TotalEquipmentWeight = 2
                },
                new GetSoldiersWithTotalEquipmentWeightData
                {
                    soldier = inputSoldier.Skip(3).First(),
                    TotalEquipmentWeight = 5
                },
                new GetSoldiersWithTotalEquipmentWeightData
                {
                    soldier = inputSoldier.Skip(4).First(),
                    TotalEquipmentWeight = 0
                }
        };

            CollectionAssert.AreEquivalent(expectedResult, result);
        }
    }
}
