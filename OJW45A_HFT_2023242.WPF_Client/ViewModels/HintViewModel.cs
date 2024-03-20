using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJW45A_HFT_2023242.WPF_Client.ViewModels
{
    public class HintViewModel
    {
        public string hint1 { get; set; }
        public string hint2 { get; set; }

        public HintViewModel()
        {
            hint1 = "How to use:\n" +
                "Create: \n\t1. Type in the properties on the left side of the window\n\t2. Click the Create Button\n" +
                "Update: \n\t1. Type in the properties on the left side of the window\n\t2. Select the entity from the list\n\t3. Click the Update Button\n" +
                "Delete: \n\t1. Select the entity from the list\n\t2. Click the Delete Button";

            hint2 = "The following restrictions apply for Creating/Deleting entitites:\n" +
                "ArmyBases:\n\tName not null and name < 50 characters\n\tBuild date > minimum date(1/1/0001)\n\tNumber of beds at least 1\n" +
                "Soldiers:\n\tName not null and name < 50 characters\n\tAge > 18\n\tArmyBaseID > 0\n" +
                "Equipment:\n\tType not null and type < 50 characters\n\tDescription < 200 characters\n\tSoldierID > 0";
        }
    }
}
