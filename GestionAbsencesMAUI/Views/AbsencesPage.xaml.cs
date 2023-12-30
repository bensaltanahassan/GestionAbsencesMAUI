using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace GestionAbsencesMAUI.Views;

public partial class AbsencesPage : ContentPage
{
    private AbsencesPageViewModel viewModel;

    public AbsencesPage()
	{
        // Add available dates
        InitializeComponent();
        InitializePage();

    }

    public async Task InitializePage()
    {
        viewModel = new AbsencesPageViewModel();
        await viewModel.InitializeViewModel();
        this.BindingContext = viewModel;
    }
 

    private async void OnModuleSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedModule = (sender as Picker)?.SelectedItem as string;
        if (selectedModule != null)
        {
            await viewModel.OnSelectedModuleChanged(selectedModule);
            this.FilierePicker.ItemsSource = viewModel.filieresNames;
        }
    }

    private async void OnFiliereSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedFiliere = (sender as Picker)?.SelectedItem as string;
        if (selectedFiliere != null)
        {
            await viewModel.OnSelectedFiliereChanged(selectedFiliere);
            this.DatesPicker.ItemsSource = viewModel.sessionsDates;
        }
    }


    public async void OnDateSelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedDate = (sender as Picker)?.SelectedItem as string;
        if (selectedDate != null)
        {
            if (selectedDate=="Add new session")
            {
                this.DatePicker.IsVisible = true;
            }
            else
            {
                this.DatePicker.IsVisible = false;
                viewModel.selectedDate = selectedDate;
                await viewModel.OnSelectedSessionChanged(selectedDate);
            }
        }
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        var selectedDate = e.NewDate.ToString("dd/MM/yyyy"); 
        viewModel.selectedDate = selectedDate;
        await viewModel.OnSelectedSessionChanged(selectedDate);
    }



}