namespace RentACarM;
using RentACarM.Models;
public partial class GymEntryPage : ContentPage
{
	public GymEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetGymsAsync();
    }
    async void OnGymAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new GymPage
        {
            BindingContext = new Gym()
        });
    }
    async void OnListViewItemSelected(object sender,
   SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new GymPage
            {
                BindingContext = e.SelectedItem as Gym
            });
        }
    }
}