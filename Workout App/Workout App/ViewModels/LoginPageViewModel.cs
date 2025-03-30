using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Workout_App.Views;
using Xamarin.Forms;

namespace Workout_App.ViewModels
{

    
    internal class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand LoginCommand { get; }
        public ICommand SignupCommand { get; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new AppShell()));
            SignupCommand = new Command(async () => await Application.Current.MainPage.Navigation.PushAsync(new SignupPage()));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
