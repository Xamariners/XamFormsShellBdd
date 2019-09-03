using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamForms.Shell.Bdd.Views;

namespace XamForms.Shell.Bdd
{
    public partial class App : Application
    {
        public static string Root { get; set; } = "root";

        public static App Instance => Current as App;

        public static AppShell Shell => Instance.MainPage as AppShell;

        public static AppShellViewModel ShellViewModel => Shell.BindingContext as AppShellViewModel;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static void GoToShellRootAsync(bool animate = true)
        {
            if (Shell?.Items != null && Shell.Items.Count > 0)
            {
                Shell.CurrentItem = Shell.Items.First(x => x.Route == Root);
            }
        }

        public static Page GetShellPage(object item)
        {
            if (item is null)
                return null;

            if (item is ShellContent content)
                return content.Content as Page;

            if (item is Xamarin.Forms.Shell shell)
                return GetShellPage(shell.CurrentItem);

            if (item is ShellItem shellItem)
                return GetShellPage(shellItem.CurrentItem);

            if (item is ShellSection shellSection)
                return GetShellPage(shellSection.CurrentItem);

            return null;
        }

        public static TViewModel GetCurrentViewModel<TViewModel>() where TViewModel : class
        {
            var page = GetShellPage(Application.Current.MainPage);
            return page?.BindingContext as TViewModel;
        }
    }
}
