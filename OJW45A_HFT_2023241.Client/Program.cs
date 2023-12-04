using ConsoleTools;
using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;

namespace OJW45A_HFT_2023241.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "ArmyBase")
            {
                try
                {
                    //Name
                    Console.Write("Enter Base Name: ");
                    string name = Console.ReadLine();
                    //Dateofbuild
                    Console.Write("Enter date of build in DD/MM/YYYY: ");
                    DateTime dateOfBuild = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    //Numberofbeds
                    Console.Write("Enter number of beds: ");
                    int numberOfBeds = int.Parse(Console.ReadLine());
                    rest.Post(new ArmyBase() { Name = name, DateOfBuild = dateOfBuild, NumberOfBeds = numberOfBeds }, "armybase");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (entity == "Soldier")
            {
                try
                {
                    //Name
                    Console.Write("Enter Soldier Name: ");
                    string name = Console.ReadLine();
                    //Age
                    Console.Write("Enter Soldier Age: ");
                    int age = int.Parse(Console.ReadLine());
                    //Weight
                    Console.Write("Enter Soldier Weight: ");
                    int weight = int.Parse(Console.ReadLine());
                    //ArmyBaseId
                    Console.Write("Enter Soldier ArmyBaseId: ");
                    int armyBaseId = int.Parse(Console.ReadLine());
                    rest.Post(new Soldier() { Name = name, Age = age, Weight = weight, ArmyBaseId = armyBaseId }, "soldier");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (entity == "Equipment")
            {
                try
                {
                    //Type
                    Console.Write("Enter Equipment Type: ");
                    string type = Console.ReadLine();
                    //Description
                    Console.Write("Enter Equipment Description: ");
                    string description = Console.ReadLine();
                    //Weight
                    Console.Write("Enter Equipment Weight: ");
                    int weight = int.Parse(Console.ReadLine());
                    //SoldierId
                    Console.Write("Enter Equipment SoldierId: ");
                    int soldierId = int.Parse(Console.ReadLine());
                    rest.Post(new Equipment() { Type = type, Description = description, Weight = weight, SoldierId = soldierId }, "equipment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }

        static void GetOne(string entity)
        {           
            if (entity == "ArmyBase")
            {
                Console.WriteLine("Enter ArmyBase id: ");
                try
                {                
                    int id = int.Parse(Console.ReadLine());
                    ArmyBase armyBase = rest.Get<ArmyBase>(id, "armybase");
                    Console.WriteLine(armyBase.Id + ": " + armyBase.Name + "\tDate of build: " + armyBase.DateOfBuild);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return;
                }               
            }
            else if (entity == "Soldier")
            {
                Console.WriteLine("Enter Soldier id: ");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Soldier soldier = rest.Get<Soldier>(id, "soldier");
                    Console.WriteLine(soldier.Id + ": " + soldier.Name + "\tAge: " + soldier.Age);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return;
                }
            }
            else if (entity == "Equipment")
            {
                Console.WriteLine("Enter Equipment id: ");
                try
                {
                    int id = int.Parse(Console.ReadLine());
                    Equipment equipment = rest.Get<Equipment>(id, "equipment");
                    Console.WriteLine(equipment.Id + ": " + equipment.Type + "\tWeight: " + equipment.Weight);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                    return;
                }
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "ArmyBase")
            {
                List<ArmyBase> bases = rest.Get<ArmyBase>("armybase");
                foreach (var item in bases)
                {
                    Console.WriteLine(item.Id + ": " + item.Name + "\tDate of build: " + item.DateOfBuild);
                }
            }
            else if (entity == "Soldier")
            {
                List<Soldier> bases = rest.Get<Soldier>("soldier");
                foreach (var item in bases)
                {
                    Console.WriteLine(item.Id + ": " + item.Name + "\tAge: " + item.Age);
                }
            }
            else if (entity == "Equipment")
            {
                List<Equipment> bases = rest.Get<Equipment>("equipment");
                foreach (var item in bases)
                {
                    Console.WriteLine(item.Id + ": " + item.Type + "\tWeight: " + item.Weight);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "ArmyBase")
            {
                try
                {
                    Console.Write("Enter ArmyBase id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    ArmyBase one = rest.Get<ArmyBase>(id, "armybase");
                    Console.Write($"New name [old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;
                    rest.Put(one, "armybase");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }              
            }
            else if (entity == "Soldier")
            {
                try
                {
                    Console.Write("Enter Soldier id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Soldier one = rest.Get<Soldier>(id, "soldier");
                    Console.Write($"New name [old: {one.Name}]: ");
                    string name = Console.ReadLine();
                    one.Name = name;
                    rest.Put(one, "soldier");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }              
            }
            else if (entity == "Equipment")
            {
                try
                {
                    Console.Write("Enter Equipment id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Equipment one = rest.Get<Equipment>(id, "equipment");
                    Console.Write($"New type [old: {one.Type}]: ");
                    string name = Console.ReadLine();
                    one.Type = name;
                    rest.Put(one, "equipment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }             
            }
        }
        static void Delete(string entity)
        {
            if (entity == "ArmyBase")
            {
                try
                {
                    Console.Write("Enter ArmyBase id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "armybase");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                
            }
            else if (entity == "Soldier")
            {
                try
                {
                    Console.Write("Enter Soldier id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "soldier");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
                
            }
            else if (entity == "Equipment")
            {
                try
                {
                    Console.Write("Enter Equipment id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "equipment");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
        static void NonCrud(string variable)
        {
            if (variable == "GetBasesWithAverageSoldierAge")
            {
                try
                {
                    List<GetBasesWithAverageSoldierAgeData> bases = rest.Get<GetBasesWithAverageSoldierAgeData>("NonCrud/GetBasesWithAverageSoldierAge");
                    foreach (var item in bases)
                    {
                        Console.WriteLine(item.BaseName + "\tAverage age: " + item.AverageSoldierAge);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (variable == "GetArmyBaseStatistics")
            {
                try
                {
                    List<ArmyBaseData> bases = rest.Get<ArmyBaseData>("noncrud/GetArmyBaseStatistics");
                    foreach (var item in bases)
                    {
                        Console.WriteLine(item.BaseName + "\tNumber of soldiers: " + item.Count + "\tAverage weight: " + item.AvgWeight + "\tAverage age: " + item.AvgAge);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (variable == "GetEquipmentCountByTypePerBase")
            {
                try
                {
                    List<GetEquipmentCountByTypePerBaseData> bases = rest.Get<GetEquipmentCountByTypePerBaseData>("noncrud/GetEquipmentCountByTypePerBase");
                    foreach (var item in bases)
                    {
                        Console.WriteLine(item.BaseName + "\tEquipment Type: " + item.EquipmentType + "\tEquipment Count: " + item.EquipmentCount);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (variable == "GetSoldiersWithEquipmentTypes")
            {
                try
                {
                    List<KeyValuePair<Soldier, IEnumerable<string>>> bases = rest.Get<KeyValuePair<Soldier, IEnumerable<string>>>("noncrud/GetSoldiersWithEquipmentTypes");
                    foreach (var item in bases)
                    {
                        Console.WriteLine(item.Key.Name);
                        foreach (var item2 in item.Value)
                        {
                            Console.WriteLine("\t" + item2);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            else if (variable == "GetSoldiersWithTotalEquipmentWeight")
            {
                try
                {
                    List<GetSoldiersWithTotalEquipmentWeightData> bases = rest.Get<GetSoldiersWithTotalEquipmentWeightData>("noncrud/GetSoldiersWithTotalEquipmentWeight");
                    foreach (var item in bases)
                    {
                        Console.WriteLine(item.soldier.Name + "\tTotal weight: " + item.TotalEquipmentWeight);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:36154/", "armybase");

            var baseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Get Base", () => GetOne("ArmyBase"))
                .Add("List", () => List("ArmyBase"))
                .Add("Create", () => Create("ArmyBase"))
                .Add("Delete", () => Delete("ArmyBase"))
                .Add("Update", () => Update("ArmyBase"))
                .Add("Exit", ConsoleMenu.Close);

            var soldierSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Get Soldier", () => GetOne("Soldier"))
                .Add("List", () => List("Soldier"))
                .Add("Create", () => Create("Soldier"))
                .Add("Delete", () => Delete("Soldier"))
                .Add("Update", () => Update("Soldier"))
                .Add("Exit", ConsoleMenu.Close);

            var equipmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Get Equipment", () => GetOne("Equipment"))
                .Add("List", () => List("Equipment"))
                .Add("Create", () => Create("Equipment"))
                .Add("Delete", () => Delete("Equipment"))
                .Add("Update", () => Update("Equipment"))
                .Add("Exit", ConsoleMenu.Close);

            var noncrudSubMenu = new ConsoleMenu(args, level: 1)
                .Add("GetBasesWithAverageSoldierAge", () => NonCrud("GetBasesWithAverageSoldierAge"))
                .Add("GetArmyBaseStatistics", () => NonCrud("GetArmyBaseStatistics"))
                .Add("GetEquipmentCountByTypePerBase", () => NonCrud("GetEquipmentCountByTypePerBase"))
                .Add("GetSoldiersWithEquipmentTypes", () => NonCrud("GetSoldiersWithEquipmentTypes"))
                .Add("GetSoldiersWithTotalEquipmentWeight", () => NonCrud("GetSoldiersWithTotalEquipmentWeight"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Bases", () => baseSubMenu.Show())
                .Add("Soldiers", () => soldierSubMenu.Show())
                .Add("Equipment", () => equipmentSubMenu.Show())
                .Add("Non-Crud", () => noncrudSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
