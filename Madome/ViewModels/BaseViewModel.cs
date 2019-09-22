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

        public string getUserAffiliation
        {
            get => account.Affiliation;
        }

        public string getUserPhoneNumber
        {
            get => account.Phone;
        }

        public string getUserName
        {
            get => account.Name;
        }

    }
}
