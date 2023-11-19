using NUnit.Framework;
using OJW45A_HFT_2023241.Logic;
using OJW45A_HFT_2023241.Models;
using OJW45A_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023241.Test
{
    public class FakeArmyBaseRepository : IRepository<ArmyBase>
    {
        public void Create(ArmyBase item)
        { 
            //Has been deleted to simulate correct data received
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ArmyBase Read(int id)
        {
            return null;
        }

        public IQueryable<ArmyBase> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ArmyBase item)
        {
            throw new NotImplementedException();
        }
    }

    public class FakeSoldierRepository : IRepository<Soldier>
    {
        public void Create(Soldier item)
        {
            //Has been deleted to simulate correct data received
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Soldier Read(int id)
        {
            return null;
        }

        public IQueryable<Soldier> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Soldier item)
        {
            throw new NotImplementedException();
        }
    }   

    public class FakeEquipmentRepository : IRepository<Equipment>
    {
        public void Create(Equipment item)
        {
            //Has been deleted to simulate correct data received
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Equipment Read(int id)
        {
            return null;
        }

        public IQueryable<Equipment> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Equipment item)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class CrudTests
    {
        IArmyBaseLogic armyBaseLogic;
        ISoldierLogic soldierLogic;
        IEquipmentLogic equipmentLogic;

        [SetUp]
        public void SetUp()
        {
            armyBaseLogic = new ArmyBaseLogic(new FakeArmyBaseRepository());
            soldierLogic = new SoldierLogic(new FakeSoldierRepository());
            equipmentLogic = new EquipmentLogic(new FakeEquipmentRepository());
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
            //In this example all should be correct, no exception should be thrown
            Assert.That(() => armyBaseLogic.Create(new ArmyBase
            {
                Name = "AllCorrect",
                NumberOfBeds = 10,
                DateOfBuild = new DateTime(2002, 10, 10)
            }), Throws.Nothing);
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
            Assert.That(() => soldierLogic.Create(new Soldier 
            { 
                Name = "AllCorrecr", 
                Age = 18, 
                ArmyBaseId = 1 
            }), Throws.Nothing);
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
            Assert.That(() => equipmentLogic.Create(new Equipment 
            { 
                Type = "AllCorrect", 
                Weight = 100,
                SoldierId = 1
            }), Throws.Nothing);
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
