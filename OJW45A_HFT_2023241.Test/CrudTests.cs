using Moq;
using NUnit.Framework;
using OJW45A_HFT_2023241.Logic.LogicInterfaces;
using OJW45A_HFT_2023241.Logic.Logics;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Test
{
    [TestFixture]
    public class CrudTests
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
            mockArmyBaseRepository = new Mock<IRepository<ArmyBase>>();
            mockSoldierRepository = new Mock<IRepository<Soldier>>();
            mockEquipmentRepository = new Mock<IRepository<Equipment>>();

            armyBaseLogic = new ArmyBaseLogic(mockArmyBaseRepository.Object);
            soldierLogic = new SoldierLogic(mockSoldierRepository.Object);
            equipmentLogic = new EquipmentLogic(mockEquipmentRepository.Object);
        }

        //Only testing the exceptions of these crud methods

        [Test]
        public void ArmyBaseCreateTest1()
        {
            //In this example, the bed numbers have not been given, this should result in an exception
            Assert.That(() => armyBaseLogic.Create(new ArmyBase { Name = "NumberOfBedsNotGiven", DateOfBuild = new DateTime(2002, 10, 10) }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArmyBaseCreateTest2()
        {
            //In this example, the date of build has not been given, this should result in an exception
            Assert.That(() => armyBaseLogic.Create(new ArmyBase { Name = "DateOfBuildNotGiven", NumberOfBeds = 10 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArmyBaseCreateTest3()
        {
            //In this example, the base name is too long, this should result in an exception
            Assert.That(() => armyBaseLogic.Create(new ArmyBase { Name = new string('x', 51), NumberOfBeds = 10, DateOfBuild = new DateTime(2002, 10, 10) }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArmyBaseCreateTest4()
        {
            //In this example, the base name is null, this should result in an exception
            Assert.That(() => armyBaseLogic.Create(new ArmyBase { Name = null, NumberOfBeds = 10, DateOfBuild = new DateTime(2002, 10, 10) }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArmyBaseCreateTest5()
        {
            //In this example, all should be correct, no exception should be thrown
            var test = new ArmyBase { Name = "AllCorrect", NumberOfBeds = 10, DateOfBuild = new DateTime(2002, 10, 10) };

            armyBaseLogic.Create(test);

            mockArmyBaseRepository.Verify(x => x.Create(test), Times.Once);
        }


        [Test]
        public void SoldierCreateTest1()
        {
            //In this example, the age of the soldier is too small, this should result in an exception
            Assert.That(() => soldierLogic.Create(new Soldier { Name = "TooYoung", Age = 17, ArmyBaseId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void SoldierCreateTest2()
        {
            //In this example, the armybaseid is not given, this should result in an exception
            Assert.That(() => soldierLogic.Create(new Soldier { Name = "NoArmyBaseId", Age = 18}), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void SoldierCreateTest3()
        {
            //In this example, the name of the soldier is null, this should result in an exception
            Assert.That(() => soldierLogic.Create(new Soldier { Name = null, Age = 18, ArmyBaseId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void SoldierCreateTest4()
        {
            //In this example, the name of the soldier is too long, this should result in an exception
            Assert.That(() => soldierLogic.Create(new Soldier { Name = new string('x', 51), Age = 18, ArmyBaseId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void SoldierCreateTest5()
        {
            //In this example, all should be correct, no exception should be thrown
            var test = new Soldier { Name = "AllCorrecr", Age = 18, ArmyBaseId = 1 };

            soldierLogic.Create(test);

            mockSoldierRepository.Verify(x => x.Create(test), Times.Once);
        }


        [Test]
        public void EquipmentCreateTest1()
        {
            //In this example, the type of the equipment is null, this should result in an exception
            Assert.That(() => equipmentLogic.Create(new Equipment { Type = null, Weight = 100, SoldierId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EquipmentCreateTest2()
        {
            //In this example, the type of the equipment is too long, this should result in an exception
            Assert.That(() => equipmentLogic.Create(new Equipment { Type = new string('x', 51), Weight = 100, SoldierId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EquipmentCreateTest3()
        {
            //In this example, the description of the equipment hould be too long, this should result in an exception
            Assert.That(() => equipmentLogic.Create(new Equipment { Type = "DescriptionTooLong", Description =new string('x', 201), Weight = 100, SoldierId = 1 }), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EquipmentCreateTest4()
        {
            //In this example, the type of the equipment is too long, this should result in an exception
            Assert.That(() => equipmentLogic.Create(new Equipment { Type = "NoSoldierId", Weight = 100}), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void EquipmentCreateTest5()
        {
            //In this example, all should be correct, no exception should be thrown
            var test = new Equipment{Type = "AllCorrect", Weight = 100, SoldierId = 1 };

            equipmentLogic.Create(test);

            mockEquipmentRepository.Verify(x => x.Create(test), Times.Once);
        }


        //The Read and Delete works the same on all 3 logics, it is enough to test it on one of them
        [Test]
        public void GeneralReadTest()
        {
            //The fake repository returns null in the Read() method, this should result in an exception
            Assert.That(() => armyBaseLogic.Read(1), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GeneralDeleteTest()
        {
            //The fake repository returns null in the Read() method, which is then used by the logic Delete method, this should result in an exception
            Assert.That(() => armyBaseLogic.Delete(1), Throws.TypeOf<ArgumentException>());
        }
    }
}
