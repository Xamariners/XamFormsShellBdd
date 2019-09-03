using System.IO;
using BoDi;
using PCLAppConfig;
using TechTalk.SpecFlow;

namespace XamForms.Shell.Bdd.Test.Infrastructure
{
    [Binding]
    public class SetupHooks
    {
        protected readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;
        private bool _isConfigManagerSet;

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

            SetConfigManager("XamForms.Shell.Bdd.Test.dll.config");
            Application = new App();
        }

        [AfterScenario]
        public virtual void AfterScenario()
        {
            Application = null;
            _objectContainer.Dispose();
            _scenarioContext.Clear();
        }

        private void SetConfigManager(string configFilename)
        {
            if (_isConfigManagerSet)
                return;

            var configPath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, configFilename);
            var s = File.Open(configPath, FileMode.Open);

            try
            {
                ConfigurationManager.Initialise(s);
            }
            catch { }

            _isConfigManagerSet = true;
        }
    }
}
