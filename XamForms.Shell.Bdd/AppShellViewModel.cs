using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using MvvmHelpers;
using XamForms.Shell.Bdd.Views;

namespace XamForms.Shell.Bdd
{
    public class AppShellViewModel : BaseViewModel
    {
        private bool _flyOutIsOpen;

        public bool IsAuthenticated { get; set; }
      
        public AppShellViewModel()
        {
            
        }

        public async Task GoToLogin()
        {
            await App.Shell.GoToAsync(nameof(LoginPage).ToLower());
        }

      

        public async Task Logout()
        {
            // ad logout logic 

            App.GoToShellRootAsync();
        }
    }
}
