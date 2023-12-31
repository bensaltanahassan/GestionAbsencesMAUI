using GestionAbsencesMAUI.ViewModels;



namespace GestionAbsencesMAUI.Views;

public partial class LoginPage : ContentPage
{
    LoginPageViewModel viewModel;

    public LoginPage()
	{
		InitializeComponent();
        //binding the view to the viewmodel
        viewModel = new LoginPageViewModel(Navigation);

        // Binding the view to the viewModel
        this.BindingContext = viewModel;
        

    }
}