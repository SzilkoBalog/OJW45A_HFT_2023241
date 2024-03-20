using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OJW45A_HFT_2023242.WPF_Client.ViewModels
{
    public class SoldierViewModel : ObservableRecipient
    {
        public RestCollection<Soldier> Soldiers { get; set; }

        public ICommand CreateSoldierCommand { get; set; }

        public ICommand DeleteSoldierCommand { get; set; }

        public ICommand UpdateSoldierCommand { get; set; }

        private Soldier selectedSoldier;

        public Soldier SelectedSoldier
        {
            get { return selectedSoldier; }
            set
            {
                if (value != null)
                {
                    selectedSoldier = new Soldier()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteSoldierCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateSoldierCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Soldier createdSoldier;

        public Soldier CreatedSoldier
        {
            get { return createdSoldier; }
            set { createdSoldier = value; }
        }

        public SoldierViewModel()
        {
            Soldiers = new RestCollection<Soldier>("http://localhost:36154/", "soldier", "hub");

            CreateSoldierCommand = new RelayCommand(() =>
            {
                Soldiers.Add(new Soldier()
                {
                    Name = CreatedSoldier.Name,
                    Age = CreatedSoldier.Age,
                    Weight = CreatedSoldier.Weight,
                    ArmyBaseId = CreatedSoldier.ArmyBaseId
                });
            });

            DeleteSoldierCommand = new RelayCommand(() =>
            {
                Soldiers.Delete(SelectedSoldier.Id);
                selectedSoldier = null;
                (DeleteSoldierCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateSoldierCommand as RelayCommand).NotifyCanExecuteChanged();
            },
            () =>
            {
                return SelectedSoldier != null;
            });

            UpdateSoldierCommand = new RelayCommand(() =>
            {
                SelectedSoldier.Name = CreatedSoldier.Name;
                SelectedSoldier.Age = CreatedSoldier.Age;
                SelectedSoldier.Weight = CreatedSoldier.Weight;
                SelectedSoldier.ArmyBaseId = CreatedSoldier.ArmyBaseId;
                Soldiers.Update(SelectedSoldier);
            },
            () =>
            {
                return SelectedSoldier != null;
            });

            SelectedSoldier = null;
            CreatedSoldier = new Soldier();
        }
    }
}
