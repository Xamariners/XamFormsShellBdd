using System;
using System.Linq;
using Shouldly;
using TechTalk.SpecFlow;
using XamForms.Shell.Bdd.Test.Infrastructure;
using XamForms.Shell.Bdd.ViewModels;

namespace XamForms.Shell.Bdd.Test
{
    [Binding]
    public class LoginFeatureSteps : StepBase
    {
        private LoginPageViewModel _viewModel;

        [Given(@"I am an unauthenticated user")]
        [Then(@"I am an unauthenticated user")]
        public void GivenIAmAnUnauthenticatedUser()
        {
            _viewModel.IsAuthenticated.ShouldBeFalse();
        }

        [When(@"I enter username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenIEnterUsernameAndPassword(string username, string password)
        {
            _viewModel.Username = username;
            _viewModel.Password = password;
        }

        [When(@"I tap the login button")]
        public void WhenITapTheLoginButton()
        {
            _viewModel.LoginCommand.Execute(null);
        }

        [Then(@"I am authenticated")]
        public void ThenIAmAuthenticated()
        {
            _viewModel.IsAuthenticated.ShouldBeTrue();
        }

        [Then(@"I cannot see an Error")]
        public void ThenICannotSeeAnError()
        {
            _viewModel.Error.ShouldBeNullOrEmpty();
        }

        [Then(@"I can see an Error ""([^""]*)""")]
        public void ThenICanSeeAnError(string error)
        {
            _viewModel.Error.ShouldBe(error);
        }

        public LoginFeatureSteps(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _viewModel = App.GetCurrentViewModel<LoginPageViewModel>();
        }
    }
}
