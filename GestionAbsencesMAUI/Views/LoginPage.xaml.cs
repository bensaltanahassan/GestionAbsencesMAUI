using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class LoginPage : ContentPage
{
    LoginPageViewModel viewModel;

    public LoginPage()
	{
		InitializeComponent();
		//binding the view to the viewmodel
		this.BindingContext = viewModel = new LoginPageViewModel();


	}
}