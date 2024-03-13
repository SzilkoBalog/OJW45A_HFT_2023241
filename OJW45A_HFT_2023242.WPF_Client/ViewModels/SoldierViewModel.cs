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

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public SoldierViewModel()
        {
            Soldiers = new RestCollection<Soldier>("http://localhost:36154/", "soldier", "hub");

            //Try-Catchek egyenlore nem mukodnek

            CreateSoldierCommand = new RelayCommand(() =>
            {
                try
                {
                    Soldiers.Add(new Soldier()
                    {
                        Name = SelectedSoldier.Name
                    });
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            });

            DeleteSoldierCommand = new RelayCommand(() =>
            {
                Soldiers.Delete(SelectedSoldier.Id);
            },
            () =>
            {
                return SelectedSoldier != null;
            });

            UpdateSoldierCommand = new RelayCommand(() =>
            {
                try
                {
                    Soldiers.Update(SelectedSoldier);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            },
            () =>
            {
                return SelectedSoldier != null;
            });

            //SelectedArmyBase = null; ----> Ez amiatt van, hogy ha createl-ni akarunk azelott hogy kivalasztottunk army-baset --> Kell majd erre valami elegansabb megoldas
        }
    }
}
