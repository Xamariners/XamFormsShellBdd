using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamForms.Shell.Bdd.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand { get; set; }

        public string Error { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command( _ => Login());
        }

        private void Login()
        {
            // TODO: hook your service here
            // we'll just hard code for demo purposes

            if (Username == "goodUserName" && Password == "goodPassword")
            {
                IsAuthenticated = true;
                Error = "";
            }
            else
            {
                Error = "Invalid Credentials";
            }
        }
    }
}
