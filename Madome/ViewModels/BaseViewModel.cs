using System;
using Madome.Custom.Auth;
using Xamarin.Forms;

namespace Madome.ViewModels
{
    public class BaseViewModel
    {
        public App AppCurrent{
            get
            {
                return (App)Xamarin.Forms.Application.Current;
            }
        }
        public IAccountManager account
        {
            get => DependencyService.Get<IAccountManager>();
        }

        public string getUserID
        {
            get => account.Id;
        }

        public string getUserEmail
        {
            get => account.Email;
        }

        public string getUserName
        {
            get => account.Name;
        }

    }
}
