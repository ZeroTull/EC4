using EC4_Automation.Helpers.AutoIDs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace EC4_Automation
{
    public class LoginModel
    {
        public TextBox loginTextBox { get; private set; }
        public TextBox passwordField { get; private set; }
        public TextBox clientField { get; private set; }
        public Button loginButton { get; private set; }
        public CheckBox rememberMeCheckBox { get; private set; }
        public ComboBox desk { get; private set; }

        public LoginModel(Window loginWindow)
        {
            loginTextBox = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId(LoginWindowIDs.LOGINTEXTBOX));
            passwordField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId(LoginWindowIDs.PASSWORDTEXTBOX));
            clientField = loginWindow.Get<TextBox>(SearchCriteria.ByAutomationId(LoginWindowIDs.CLIENDTEXTBOX));
            rememberMeCheckBox = loginWindow.Get<CheckBox>(SearchCriteria.ByClassName(LoginWindowIDs.REMEMBERMECHECKBOX));
            loginButton = loginButton = loginWindow.Get<Button>(SearchCriteria.ByAutomationId(LoginWindowIDs.LOGINBUTTON));
        }
        public void Login(string login, string pwd, string client, bool rememberMe)
        {
            loginTextBox.Text = login;
            passwordField.Text = pwd;
            clientField.Text = client;
            rememberMeCheckBox.Checked = rememberMe;
            loginButton.Click();
        }
        //TODO
        /*public void CheckDeskSelectionDropdown(Window loginWindow)
        
        {
            while (desk == null)
            {
                desk = loginWindow.Get<ComboBox>(SearchCriteria.ByAutomationId(DeskSelectionIDs.DESKSELECTIONCOMBOBOX));
            }
        }
        */
    }
}
