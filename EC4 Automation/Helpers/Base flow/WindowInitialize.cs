using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace EC4_Automation.Helpers.Base_flow
{
    public class WindowInitialize
    {
        private class ApplicationInitialize
        {
            public Application app { get; private set; }
            public ApplicationInitialize()
            {
                app = Application.Launch(@"D:\EchoContactClient.Host.exe.lnk");
            }
        }
        public Window loginWindow { get; private set; }
                
        public WindowInitialize()
        {
            ApplicationInitialize EC4 = new ApplicationInitialize();
            loginWindow = EC4.app.GetWindow(SearchCriteria.ByClassName("Window"), InitializeOption.NoCache);
        }
    }
}
