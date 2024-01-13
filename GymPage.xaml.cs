namespace RentACarM;

using Microsoft.Maui.Devices.Sensors;
using RentACarM.Models;
using SQLite;
using SQLiteNetExtensions.Attributes;
public partial class GymPage : ContentPage
{
	public GymPage()
	{
		InitializeComponent();
    }
    async void OnSaveButtonClicked2(object sender, EventArgs e)
    {
        var gym = (Gym)BindingContext;
        await App.Database.SaveGymAsync(gym);
        await Navigation.PopAsync();
    }

}