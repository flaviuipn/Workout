namespace RentACarM;
using System;
using RentACarM.Data;
using System.IO;


public partial class App : Application
{
    static WorkoutListDatabase database;

    public static WorkoutListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new WorkoutListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WorkoutList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
