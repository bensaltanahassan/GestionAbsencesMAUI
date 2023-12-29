using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class StudentPage : ContentPage
{
	public StudentPage()
	{
        InitializeComponent();
        BindingContext = new StudentPageViewModel();
    }
}