using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamForms.Shell.Bdd.Views;

namespace XamForms.Shell.Bdd.ViewModels
{
    public class ViewModelLocator
    {
        private const string DEFAULT_ROUTE = "//root/";

        /// <summary>
        /// ViewModelLocator constructor
        /// </summary>
        static ViewModelLocator()
        {
            Init();
        }

        // Add the view model locator property for the registered class and bind the context on the XAML.
        // See HomePageViewModel as the example

        // CORE
        public AppShellViewModel AppShell => new AppShellViewModel();
        public HomePageViewModel HomePage => new HomePageViewModel();

        // AUTH
        public LoginPageViewModel LoginPage => new LoginPageViewModel();
       
        public static void Init()
        {
            // Register anything related to this shared projects including *ViewModels.
            // After registering the page to Unity container, make sure to define the
            // property of the view model as well. See below part.

            // CORE
            DependencyService.Register<AppShellViewModel>();
        }
    }
}
