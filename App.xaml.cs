using ProiectTry.Data;
using System;
using System.IO;
namespace ProiectTry;

public partial class App : Application
{
    static EchipamentDatabase database;
    public static EchipamentDatabase Database { get { if (database == null) { database = new EchipamentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Echipament.db3")); } return database; } }
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
