using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class StudentPage : ContentPage
{
    private InfoPageViewModel _viewModel;
    public StudentPage()
	{
        InitializeComponent();
        BindingContext = new StudentPageViewModel();
    }
}