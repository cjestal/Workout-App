using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Workout_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseLibraryPage : ContentPage
    {
        public ExerciseLibraryPage()
        {
            InitializeComponent();
            BindingContext = new ExerciseLibraryViewModel(); // Instantiate ViewModel
        }
    }
}