namespace RentACarM;
using RentACarM.Models;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
 
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExercisePage((WorkoutList)
       this.BindingContext)
        {
            BindingContext = new Exercise()
        });

    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var workoutl = (WorkoutList)BindingContext;

        listView.ItemsSource = await App.Database.GetListExercisesAsync(workoutl.ID);
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (WorkoutList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveWorkoutListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (WorkoutList)BindingContext;
        await App.Database.DeleteWorkoutListAsync(slist);
        await Navigation.PopAsync();
    }

}