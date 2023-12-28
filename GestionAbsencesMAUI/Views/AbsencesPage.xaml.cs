using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class AbsencesPage : ContentPage


{


	public AbsencesPage()
	{
    InitializeComponent();
		this.BindingContext = new AbsencesPageViewModel();
    }


    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedOption = picker.SelectedItem as string;
    }

}