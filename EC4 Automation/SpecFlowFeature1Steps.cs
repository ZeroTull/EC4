using System;
using TechTalk.SpecFlow;

namespace EC4_Automation
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have clicked Login button")]
        public void GivenIHaveClickedLoginButton()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
