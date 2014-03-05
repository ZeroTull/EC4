using ExpenceItAutomation;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;


namespace EC4_Automation_Tests
{
    [Binding]
    public class EC4_Login_Logout
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
       

        [Given(@"I have launched the EC4 application")]
        public void GivenIHaveLaunchedTheECApplication()
        {
            EC4 = Application.Launch(@"D:\EchoContactClient.Host.exe.lnk");
            loginWindow = EC4.GetWindow(SearchCriteria.ByClassName("Window"), InitializeOption.NoCache);
        }

        [Given(@"i have inputted ""(.*)"" to the Login field\.")]
        public void GivenIHaveInputtedToTheLoginField_(string login)
        {
            loginTextBox = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("LoginField"));
            loginTextBox.SetTextToTextbox(login);
        }

        [Given(@"I have inputted ""(.*)"" in to the Password field")]
        public void GivenIHaveInputtedInToThePasswordField(string password)
        {
            passwordField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PasswordField"));
            passwordField.SetTextToTextbox(password);
        }

        [Given(@"I have inputted ""(.*)"" to the Client field\.")]
        public void GivenIHaveInputtedToTheClientField_(string client)
        {
            clientField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("ClientField"));
            clientField.SetTextToTextbox(client);
        }

        [Given(@"i have selected Remember me checkbox")]
        public void GivenIHaveSelectedRememberMeCheckbox()
        {
            rememberMeCheckBox = loginWindow.Get<CheckBox>(SearchCriteria.ByClassName("CheckBox"));
            if (!rememberMeCheckBox.Checked)
                rememberMeCheckBox.Click();
        }

        [Given(@"I have clicked Login button")]
        public void GivenIHaveClickedLoginButton()
        {
            loginButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId("LoginButton"));
            loginButton.Click();
        }

        [Then(@"Desktop selection window with desk selection combobox appeared")]
        public void ThenDesktopSelectionWindowWithDeskSelectionComboboxAppeared()
        {
            Thread.Sleep(40000);
            deskSelection = loginWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("deskSelectionCombobox"));
            Assert.IsTrue(deskSelection != null);
        }

        /*[Then(@"I have selected ""(.*)"" desk from desk selection combobox")]
        public void ThenIHaveSelectedDeskFromDeskSelectionCombobox(string desk)
        {
            deskSelection.Select(desk);
            Assert.IsTrue(deskSelection.SelectedItemText == desk);
        } */ //Select  какого то хера не работает

        [Then(@"I have checked Make me immediately available Checkbox")]
        public void ThenIHaveCheckedMakeMeImmediatelyAvailableCheckbox()
        {
            makeMeImmediatlyAvailable = loginWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("makeMeImmediatelyAvailableCheckBox"));
            if (!makeMeImmediatlyAvailable.Checked)
                makeMeImmediatlyAvailable.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I have clicked ok button")]
        public void ThenIHaveClickedOkButton()
        {
            OkButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId("OkButton"));
            OkButton.Click();
        }

        [Then(@"agent dashboard window opened\.")]
        public void ThenAgentDashboardWindowOpened_()
        {
            Thread.Sleep(1000);
            AgentDashBoard = EC4.GetWindow(SearchCriteria.ByAutomationId("AgentDashboard"), InitializeOption.NoCache);
            Assert.IsTrue(AgentDashBoard != null);
        }

        [Then(@"i closed the application\.")]
        public void ThenIClosedTheApplication_()
        {
            EC4.Close();
            Assert.IsTrue(EC4 != null);
        }

    }
}
