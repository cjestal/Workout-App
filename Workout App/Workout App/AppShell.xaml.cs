using System;
using System.Collections.Generic;
using Workout_App.ViewModels;
using Workout_App.Views;
using Xamarin.Forms;

namespace Workout_App
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
