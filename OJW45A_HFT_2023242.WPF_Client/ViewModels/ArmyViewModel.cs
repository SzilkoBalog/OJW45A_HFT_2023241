using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OJW45A_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OJW45A_HFT_2023242.WPF_Client.ViewModels
{
    public class ArmyViewModel : ObservableRecipient
    {
        public RestCollection<ArmyBase> ArmyBases { get; set; }

        public ICommand CreateArmyBaseCommand { get; set; }

        public ICommand DeleteArmyBaseCommand { get; set; }

        public ICommand UpdateArmyBaseCommand { get; set; }

        private ArmyBase selectedArmyBase;

        public ArmyBase SelectedArmyBase
        {
            get { return selectedArmyBase; }
            set
            {
                if (value != null)
                {
                    selectedArmyBase = new ArmyBase()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteArmyBaseCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateArmyBaseCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private ArmyBase createdArmyBase;

        public ArmyBase CreatedArmyBase
        {
            get { return createdArmyBase; }
            set { createdArmyBase = value; }
        }

        private DateTime temp;

        public ArmyViewModel()
        {
            ArmyBases = new RestCollection<ArmyBase>("http://localhost:36154/", "armybase", "hub");

            CreateArmyBaseCommand = new RelayCommand(() =>
            {                
                ArmyBases.Add(new ArmyBase()
                {
                    Name = CreatedArmyBase.Name,
                    DateOfBuild = CreatedArmyBase.DateOfBuild,
                    NumberOfBeds = CreatedArmyBase.NumberOfBeds
                });
            });

            DeleteArmyBaseCommand = new RelayCommand(() =>
            {
                ArmyBases.Delete(SelectedArmyBase.Id);
                selectedArmyBase = null;
                (DeleteArmyBaseCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateArmyBaseCommand as RelayCommand).NotifyCanExecuteChanged();
            },
            () =>
            {
                return SelectedArmyBase != null;
            });

            UpdateArmyBaseCommand = new RelayCommand(() =>
            {
                SelectedArmyBase.Name = CreatedArmyBase.Name;
                SelectedArmyBase.DateOfBuild = CreatedArmyBase.DateOfBuild;
                SelectedArmyBase.NumberOfBeds = CreatedArmyBase.NumberOfBeds;
                ArmyBases.Update(SelectedArmyBase);
            },
            () =>
            {
                return SelectedArmyBase != null;
            });

            SelectedArmyBase = null;
            CreatedArmyBase = new ArmyBase() { DateOfBuild = DateTime.Now};
        }
    }
}
