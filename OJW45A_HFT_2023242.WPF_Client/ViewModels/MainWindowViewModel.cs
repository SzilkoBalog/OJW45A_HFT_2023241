using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OJW45A_HFT_2023242.WPF_Client.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OJW45A_HFT_2023242.WPF_Client.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private UserControl currentControl;

        public UserControl CurrentControll
        {
            get { return currentControl; }
            set { SetProperty(ref currentControl, value); }
        }


        public ICommand SetArmyCommand { get; set; }
        public ICommand SetSoldierCommand { get; set; }
        public ICommand SetEquipmentCommand { get; set; }
        public ICommand SetNonCrudCommand { get; set; }


        private ArmyUserControl armyControl;
        private SoldierUserControl soldierControl;
        private EquipmentUserControl equipmentControl;
        private NonCrudUserControl nonCrudControl;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {

                ArmyUserControl armyControl = new ArmyUserControl();
                SoldierUserControl soldierControl = new SoldierUserControl();
                EquipmentUserControl equipmentControl = new EquipmentUserControl();
                NonCrudUserControl nonCrudControl = new NonCrudUserControl();

                SetArmyCommand = new RelayCommand(() =>
                {
                    CurrentControll = armyControl;
                });

                SetSoldierCommand = new RelayCommand(() =>
                {
                    CurrentControll = soldierControl;
                });

                SetEquipmentCommand = new RelayCommand(() =>
                {
                    CurrentControll = equipmentControl;
                });

                SetNonCrudCommand = new RelayCommand(() =>
                {
                    CurrentControll = nonCrudControl;
                });
            }

        }
    }
}
