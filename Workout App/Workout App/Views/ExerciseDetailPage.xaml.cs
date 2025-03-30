using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_App.Models;
using Workout_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workout_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseDetailPage : ContentPage
    {
        
        public ExerciseDetailPage(ExerciseDTO exercise = null)
        {
            InitializeComponent();
            BindingContext = new ExerciseDetailPageViewModel(exercise);
        }
        private async void OnCloseButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}