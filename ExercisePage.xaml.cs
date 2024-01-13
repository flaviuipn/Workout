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
        var selectedExercise = listView.SelectedItem as Exercise;

        if (selectedExercise != null)
        {
            bool isUserConfirmed = await DisplayAlert("Delete Exercise", "Are you sure you want to delete this exercise?", "Yes", "No");

            if (isUserConfirmed)
            {
                await App.Database.DeleteExerciseAsync(selectedExercise);
                listView.ItemsSource = await App.Database.GetExercisesAsync();
                listView.SelectedItem = null; // Deselectează elementul selectat
            }
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
           //await Navigation.PopAsync();
        }
    }

    private Exercise selectedExercise;

    private void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        selectedExercise = e.SelectedItem as Exercise;
    }


}