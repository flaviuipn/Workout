using RentACarM.Models;
using RentACarM.Data;
namespace RentACarM;

public partial class ExercisePage : ContentPage
{
    WorkoutList w1;
    public ExercisePage(WorkoutList wlist)
    {
        InitializeComponent();
        w1 = wlist;
    }
    async void OnSaveButtonClicked1(object sender, EventArgs e)
    {
        var exercise = (Exercise)BindingContext;

        if (exercise != null)
        {
            await App.Database.SaveExerciseAsync(exercise);
            listView.ItemsSource = await App.Database.GetExercisesAsync();
        }
    }
    async void OnDeleteButtonClicked1(object sender, EventArgs e)
    {
        var exercise = (Exercise)BindingContext;

        if (exercise != null)
        {
            await App.Database.DeleteExerciseAsync(exercise);
            listView.ItemsSource = await App.Database.GetExercisesAsync();
             // Poate fi necesară această linie pentru a reveni la pagina anterioară
        }
    }
    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        if (selectedExercise != null)
        {
            var lp = new ListExercise()
            {
                WorkoutListID = w1.ID,
                ExerciseID = selectedExercise.ID
            };

            await App.Database.SaveListExerciseAsync(lp);
            selectedExercise.ListExercises = new List<ListExercise> { lp };
            listView.ItemsSource = await App.Database.GetExercisesAsync();
            await Navigation.PopAsync();
        }
    }

    private Exercise selectedExercise;

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedExercise = e.SelectedItem as Exercise;
    }


}