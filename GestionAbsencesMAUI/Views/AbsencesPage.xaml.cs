using GestionAbsencesMAUI.Models;
using GestionAbsencesMAUI.Utils;
using GestionAbsencesMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace GestionAbsencesMAUI.Views;

public partial class AbsencesPage : ContentPage
{
    private AbsencesPageViewModel viewModel;
    public List<EtudiantAbsentModel> etudiantAbsentModels { get; set; }

    public AbsencesPage()
	{

        // Add available dates
        InitializeComponent();
        InitializePage();


    }

    public async Task InitializePage()
    {
        viewModel = new AbsencesPageViewModel(Navigation);
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
                await viewModel.OnSelectedSessionChanged();
                this.StudentsCollectionView.ItemsSource = viewModel.etudiantsStatus;
            }

        }
    }

    private async void OnDateSelected(object sender, DateChangedEventArgs e)
    {
        var formattedDate = e.NewDate.ToString("dd/MM/yyyy"); 
        viewModel.formattedDate = formattedDate;
        var selectedDate = "Add new session";
        viewModel.selectedDate = selectedDate;
        await viewModel.OnSelectedSessionChanged();
        this.StudentsCollectionView.ItemsSource = viewModel.etudiantsStatus;

    }


    private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkbox = (sender as CheckBox);
        etudiantAbsentModels = new List<EtudiantAbsentModel>();
        foreach (var etudiant in viewModel.etudiantsStatus)
        {
            etudiantAbsentModels.Add(etudiant);
        }
       
    }

    private async Task IncrementProgressBarAndSaveData()
    {
        double progress = 0;
        double targetProgress = 0.5;
        const int animationDurationSeconds = 1;
        double increment = 0.01;
        double animationStep = targetProgress / (animationDurationSeconds * (1.0 / increment));
        viewModel.isLoading = true;

        while (progress < targetProgress || viewModel.isLoading )
        {
            progress += animationStep;
            if (progress > targetProgress)
            {
                progress = targetProgress;
            }
           
            this.progressBar.IsVisible = true;
            this.SaveButton.IsVisible = false;
            this.progressBar.Progress = progress;

            await Task.Delay(TimeSpan.FromSeconds(increment));

            await viewModel.saveInfoToDb();
        }

        this.progressBar.IsVisible = false;
        this.SaveButton.IsVisible = true;

        await DisplayAlert("Success", "Absences saved successfully", "OK");
    }


    private void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (viewModel.CurrentModule==null
            || viewModel.CurrentFiliere==null
            ||( viewModel.selectedDate=="Add new session" && viewModel.formattedDate==null)
            || (viewModel.selectedDate!=null && viewModel.selectedDate!="Add new session" && viewModel.CurrentSession==null)
            )
        {
            DisplayAlert("Error", "Please select all the required fields", "OK");
        }
        else
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                IncrementProgressBarAndSaveData();
                return false;
            });
        }
        
    }


}