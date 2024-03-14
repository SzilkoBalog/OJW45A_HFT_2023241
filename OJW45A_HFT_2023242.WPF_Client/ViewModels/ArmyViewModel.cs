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

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public ArmyViewModel()
        {
            ArmyBases = new RestCollection<ArmyBase>("http://localhost:36154/", "armybase", "hub");
            
            //Try-Catchek egyenlore nem mukodnek

            CreateArmyBaseCommand = new RelayCommand(() =>
            {
                try
                {
                    ArmyBases.Add(new ArmyBase()
                    {
                        Name = CreatedArmyBase.Name,
                        DateOfBuild = DateTime.ParseExact(CreatedArmyBase.DateOfBuild.Day.ToString()+"/"+ CreatedArmyBase.DateOfBuild.Month.ToString()+"/"+ CreatedArmyBase.DateOfBuild.Year.ToString(), "dd/MM/yyyy", null),
                        NumberOfBeds = CreatedArmyBase.NumberOfBeds                        
                    });
                }
                catch (ArgumentException e)
                {
                    ErrorMessage = e.Message;
                }                
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
                try
                {
                    SelectedArmyBase.Name = CreatedArmyBase.Name;
                    SelectedArmyBase.DateOfBuild = CreatedArmyBase.DateOfBuild;
                    SelectedArmyBase.NumberOfBeds = CreatedArmyBase.NumberOfBeds;
                    ArmyBases.Update(SelectedArmyBase);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            },
            () =>
            {
                return SelectedArmyBase != null;
            });

            SelectedArmyBase = null;
            CreatedArmyBase = new ArmyBase();
        }
    }
}
