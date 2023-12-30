using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
        BindingContext = new RegisterPageViewModel();
    }
}