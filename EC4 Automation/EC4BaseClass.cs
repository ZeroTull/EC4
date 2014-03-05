using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace EC4_Automation
{
    public class EC4BaseClass
    {
        public Application EC4 { get; private set; }
        public Window loginWindow { get; private set; }
        public TextBox loginTextBox { get; private set; }
        public TextBox passwordField { get; private set; }
        public TextBox clientField { get; private set; }
        public Button loginButton { get; private set; }
        public CheckBox rememberMeCheckBox { get; private set; }
        public Window desctopSelectionWindow { get; private set; }
        public ComboBox deskSelection { get; private set; }
        public CheckBox makeMeImmediatlyAvailable { get; private set; }
        public Button OkButton { get; private set; }
        public Button CancelButton { get; private set; }
        public Window AgentDashBoard { get; private set; }
        public Button VoiceLoginButton { get; private set; }
        public Button EmailLoginButton { get; private set; }
        public Button ChatLoginButton { get; private set; }


        public void ec4Main()
        {
            EC4 = Application.Launch(@"D:\EchoContactClient.Host.exe.lnk");
            loginWindow = EC4.GetWindow(SearchCriteria.ByClassName("Window"), InitializeOption.NoCache);
            loginTextBox = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("LoginField"));
            passwordField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PasswordField"));
            clientField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("ClientField"));
            rememberMeCheckBox = loginWindow.Get<CheckBox>(SearchCriteria.ByClassName("CheckBox"));
            loginButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId("LoginButton"));
            deskSelection = loginWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("deskSelectionCombobox"));
            makeMeImmediatlyAvailable = loginWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("makeMeImmediatelyAvailableCheckBox"));
            OkButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId("OkButton"));
            AgentDashBoard = EC4.GetWindow(SearchCriteria.ByAutomationId("AgentDashboard"), InitializeOption.NoCache);
        }
    }
}
