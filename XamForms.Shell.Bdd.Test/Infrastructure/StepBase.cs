using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.Forms;
using XamForms.Shell.Bdd.ViewModels;

namespace XamForms.Shell.Bdd.Test.Infrastructure
{
    public class StepBase
    {
        protected readonly ScenarioContext ScenarioContext;

        public StepBase(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }
    }
}
