using GestionAbsencesMAUI.ViewModels;
using System.Diagnostics;

namespace GestionAbsencesMAUI.Views;

public partial class MainPageChoices : ContentPage 
{
    MainPageViewModel viewModel;
	public MainPageChoices()
	{
        viewModel = new MainPageViewModel(Navigation);
        this.BindingContext = viewModel;
		InitializeComponent();
	}

    [Obsolete]
    protected override bool OnBackButtonPressed()
    {
        Device.BeginInvokeOnMainThread(async () =>
        {
            var result = await this.DisplayAlert("Confirmation", "Voulez vous vraiment quitter l'application ?", "Oui", "Non");
            if (result)
            {
                System.Environment.Exit(0);
            }
        });
        return !base.OnBackButtonPressed();
    }




}