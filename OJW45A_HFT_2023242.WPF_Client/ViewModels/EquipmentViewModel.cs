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
    public class EquipmentViewModel : ObservableRecipient
    {
        public RestCollection<Equipment> Equipment { get; set; }

        public ICommand CreateEquipmentCommand { get; set; }

        public ICommand DeleteEquipmentCommand { get; set; }

        public ICommand UpdateEquipmentCommand { get; set; }

        private Equipment selectedEquipment;

        public Equipment SelectedEquipment
        {
            get { return selectedEquipment; }
            set
            {
                if (value != null)
                {
                    selectedEquipment = new Equipment()
                    {
                        Description = value.Description,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteEquipmentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateEquipmentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        private Equipment createdEquipment;

        public Equipment CreatedEquipment
        {
            get { return createdEquipment; }
            set { createdEquipment = value; }
        }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public EquipmentViewModel()
        {
            Equipment = new RestCollection<Equipment>("http://localhost:36154/", "equipment", "hub");

            //Try-Catchek egyenlore nem mukodnek

            CreateEquipmentCommand = new RelayCommand(() =>
            {
                try
                {
                    Equipment.Add(new Equipment()
                    {
                        Type = CreatedEquipment.Type,
                        Description = CreatedEquipment.Description,
                        Weight = CreatedEquipment.Weight,
                        SoldierId = CreatedEquipment.SoldierId
                    });
                }
                catch (ArgumentException e)
                {
                    ErrorMessage = e.Message;
                }
            });

            DeleteEquipmentCommand = new RelayCommand(() =>
            {
                Equipment.Delete(SelectedEquipment.Id);
                selectedEquipment = null;
                (DeleteEquipmentCommand as RelayCommand).NotifyCanExecuteChanged();
                (UpdateEquipmentCommand as RelayCommand).NotifyCanExecuteChanged();
            },
            () =>
            {
                return SelectedEquipment != null;
            });

            UpdateEquipmentCommand = new RelayCommand(() =>
            {
                try
                {
                    SelectedEquipment.Type = CreatedEquipment.Type;
                    SelectedEquipment.Description = CreatedEquipment.Description;
                    SelectedEquipment.Weight = CreatedEquipment.Weight;
                    SelectedEquipment.SoldierId = CreatedEquipment.SoldierId;
                    Equipment.Update(SelectedEquipment);
                }
                catch (Exception e)
                {
                    ErrorMessage = e.Message;
                }
            },
            () =>
            {
                return SelectedEquipment != null;
            });

            SelectedEquipment = null;
            CreatedEquipment = new Equipment();
        }
    }
}
