using ConsoleTools;
using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;

namespace OJW45A_HFT_2023241.Client
{
    public class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "ArmyBase")
            {
                Console.Write("Enter Base Name: ");
                string name = Console.ReadLine();
                rest.Post(new ArmyBase() { Name = name }, "armybase");
            }
        }
        static void List(string entity)
        {
            if (entity == "ArmyBase")
            {
                List<ArmyBase> bases = rest.Get<ArmyBase>("armybase");
                foreach (var item in bases)
                {
                    Console.WriteLine(item.Id + ": " + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "ArmyBase")
            {
                Console.Write("Enter ArmyBase id to update: ");
                int id = int.Parse(Console.ReadLine());
                ArmyBase one = rest.Get<ArmyBase>(id, "armybase");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "armybase");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "ArmyBase")
            {
                Console.Write("Enter ArmyBase id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "armybase");
            }
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:36154/", "armybase");

            var baseSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("ArmyBase"))
                .Add("Create", () => Create("ArmyBase"))
                .Add("Delete", () => Delete("ArmyBase"))
                .Add("Update", () => Update("ArmyBase"))
                .Add("Exit", ConsoleMenu.Close);

            var soldierSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Soldier"))
                .Add("Create", () => Create("Soldier"))
                .Add("Delete", () => Delete("Soldier"))
                .Add("Update", () => Update("Soldier"))
                .Add("Exit", ConsoleMenu.Close);

            var equipmentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Equipment"))
                .Add("Create", () => Create("Equipment"))
                .Add("Delete", () => Delete("Equipment"))
                .Add("Update", () => Update("Equipment"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Bases", () => baseSubMenu.Show())
                .Add("Soldiers", () => soldierSubMenu.Show())
                .Add("Equipment", () => equipmentSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
