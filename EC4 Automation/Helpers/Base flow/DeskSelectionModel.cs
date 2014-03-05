using EC4_Automation.Helpers.AutoIDs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace EC4_Automation.Helpers.Base_flow
{
    public class DeskSelectionModel
    {
        public ComboBox deskSelection { get; private set; }
        public CheckBox makeMeImmediatlyAvailable { get; private set; }
        public Button okButton { get; private set; }
        public Button cancelButton { get; private set; }
        public Button closeButton { get; private set; }

        public DeskSelectionModel(Window window)
        {
            deskSelection = window.Get<ComboBox>(SearchCriteria.ByAutomationId(DeskSelectionIDs.DESKSELECTIONCOMBOBOX));
            makeMeImmediatlyAvailable = window.Get<CheckBox>(SearchCriteria.ByAutomationId(DeskSelectionIDs.MAKEMEIMMEDIATELYAVAILABLECHECKBOX));
            okButton = window.Get<Button>(SearchCriteria.ByAutomationId(DeskSelectionIDs.OKBUTTON));
            cancelButton = window.Get<Button>(SearchCriteria.ByAutomationId(DeskSelectionIDs.OKBUTTON));
            closeButton = window.Get<Button>(SearchCriteria.ByAutomationId(DeskSelectionIDs.CLOSEBUTTON));
        }

        public void SelectDesk(string desk, bool makeMeAvailable)
        {
            deskSelection.Select(desk);
            makeMeImmediatlyAvailable.Checked = makeMeAvailable;
            okButton.Click();        
        }

    }
}
