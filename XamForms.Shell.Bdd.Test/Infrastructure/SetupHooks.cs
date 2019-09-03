using BoDi;
using TechTalk.SpecFlow;

namespace XamForms.Shell.Bdd.Test.Infrastructure
{
    [Binding]
    public class SetupHooks
    {
        protected readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public static App Application { get; protected set; }

        public SetupHooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public virtual void BeforeScenario()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            Application = new App();
        }

        [AfterScenario]
        public virtual void AfterScenario()
        {
            Application = null;
            _objectContainer.Dispose();
            _scenarioContext.Clear();
        }
    }
}
