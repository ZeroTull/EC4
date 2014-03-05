using TechTalk.SpecFlow;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;
using ExpenceItAutomation;
using System.Threading;
using NUnit.Framework;
using EC4_Automation.Helpers.Base_flow;

namespace EC4_Automation
{
    [Binding]
    public class CreateAndSendEmail
    {
        public Application EC4 { get; private set; }
        public Window LoginWindow { get; private set; }
        public Window MainWindow { get; private set; } 
        public TextBox LoginTextBox { get; private set; }
        public TextBox PasswordField { get; private set; }
        public TextBox ClientField { get; private set; }
        public Button LoginButton { get; private set; }
        public CheckBox RememberMeCheckBox { get; private set; }
        public Window DesctopSelectionWindow { get; private set; }
        public ComboBox DeskSelection { get; private set; }
        public CheckBox MakeMeImmediatlyAvailable { get; private set; }
        public Button OkButton { get; private set; }
        public Button CancelButton { get; private set; }
        public Button MyEmailsTabButton { get; private set; }
        public Button NewEmailButton { get; private set; }
        public TextBox ToField { get; private set; }
        public TextBox SubjectField { get; private set; }
        public TextBox CCField { get; private set; }
        public Button SaveEmailButton
        {
            get
            {
                var el = MainWindow.GetElement(SearchCriteria.ByAutomationId("SaveEmailButton1"));
                var SaveEmailButton = new Button(el, MainWindow.ActionListener);
                return SaveEmailButton;
            }
            private set
            { }
        }
        public Button SaveAsDraft { get; private set; }
        public Button SendEmailButton
        {
            get
            {
                var el = MainWindow.GetElement(SearchCriteria.ByAutomationId("SendEmail"));
                var SendEmailButton = new Button(el, MainWindow.ActionListener);
                return SendEmailButton;
            }
        }

        [Given(@"I have launched appliction with ""(.*)"", ""(.*)"", ""(.*)"" credentials;")]
        public void GivenIHaveLaunchedApplictionWithCredentials(string login, string password, string client)
        {
            //Start application
            EC4 = Application.Launch(@"D:\EchoContactClient.Host.exe.lnk");
            Window LoginWindow = EC4.GetWindow(SearchCriteria.ByClassName("Window"), InitializeOption.NoCache);
            //Set login
            LoginTextBox = LoginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("LoginField"));
            LoginTextBox.SetTextToTextbox(login);
            //Set password
            PasswordField = LoginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("PasswordField"));
            PasswordField.SetTextToTextbox(password);
            //Set client
            ClientField = LoginWindow.Get<TextBox>(SearchCriteria.ByAutomationId("ClientField"));
            ClientField.SetTextToTextbox(client);
            //Check if remember me check box isn't selected
            RememberMeCheckBox = LoginWindow.Get<CheckBox>(SearchCriteria.ByClassName("CheckBox"));
            if (!RememberMeCheckBox.Checked)
                RememberMeCheckBox.Click();
            //Click Login button to open Desk selection window
            LoginButton = LoginWindow.Get<Button>(SearchCriteria.ByAutomationId("LoginButton"));
            LoginButton.Click();
            //Wait till desk selection window appears
            Thread.Sleep(40000);
            DeskSelection = LoginWindow.Get<ComboBox>(SearchCriteria.ByAutomationId("deskSelectionCombobox"));
            //Select make me immediatly available option
            MakeMeImmediatlyAvailable = LoginWindow.Get<CheckBox>(SearchCriteria.ByAutomationId("makeMeImmediatelyAvailableCheckBox"));
            if (!MakeMeImmediatlyAvailable.Checked)
                MakeMeImmediatlyAvailable.Click();
            //Click OK to open agent dashboard window
            OkButton = LoginWindow.Get<Button>(SearchCriteria.ByAutomationId("OkButton"));
            OkButton.Click();
            Thread.Sleep(2000);
            
        }

        [Given(@"I have opened My Emails tab;")]
        public void GivenIHaveOpenedMyEmailsTab()
        {
            MainWindow = EC4.GetWindow(SearchCriteria.ByAutomationId("AgentDashboard"), InitializeOption.NoCache);
            MyEmailsTabButton = MainWindow.Get<Button>(SearchCriteria.ByAutomationId("MyEmailsTabButton"));
            MyEmailsTabButton.Click();
            Thread.Sleep(1000);
        }

        [When(@"I press New;")]
        public void WhenIPressNew()
        {
            NewEmailButton = MainWindow.Get<Button>(SearchCriteria.ByAutomationId("NewEmailButton"));
            NewEmailButton.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I fill to field with ""(.*)"" Email;")]
        public void ThenIFillToFieldWithEmail(string email)
        {
            ToField = MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("ToAddress"));
            ControlsHelper.SetTextToTextbox(ToField, email);
            Thread.Sleep(1000);
        }
        [Then(@"i fill CC field with ""(.*)"" email;")]
        public void ThenIFillCCFieldWithEmail(string email)
        {
            CCField = MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("CcAddress"));
            ControlsHelper.SetTextToTextbox(CCField, email);
            Thread.Sleep(1000);
        }

        [Then(@"I fill subject field with ""(.*)"" subject;")]
        public void ThenIFillSubjectFieldWithSubject(string subject)
        {
            SubjectField = MainWindow.Get<TextBox>(SearchCriteria.ByAutomationId("Subject"));
            ControlsHelper.SetTextToTextbox(SubjectField, subject);
            Thread.Sleep(1000);
        }

        [Then(@"clicked Send button;")]
        public void ThenClickedSendButton()
        {
            SendEmailButton.Click();
            Thread.Sleep(1000);
        }

        [Then(@"I have closed appilcation\.")]
        public void ThenIHaveClosedAppilcation_()
        {
            EC4.Close();
            Assert.IsTrue(EC4 != null);
        }
    }
}
