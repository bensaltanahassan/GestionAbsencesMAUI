using GestionAbsencesMAUI.Utils;
using GestionAbsencesMAUI.ViewModels;

namespace GestionAbsencesMAUI.Views;

public partial class SearchPage : ContentPage
{
	private SearchPageViewModel viewModel;
    public List<EtudiantAbsentModel> etudiantAbsentModels { get; set; }

    public SearchPage()
	{
        InitializeComponent();
        InitializePage();
	}
    public async Task InitializePage()
    {
        viewModel = new SearchPageViewModel();
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
                viewModel.selectedDate = selectedDate;
                await viewModel.OnSelectedSessionChanged(this.CneEditor.Text);
            if (viewModel.etudiant != null)
            {
                this.studentFrame.IsVisible = true;
                this.StudentName.Text = viewModel.etudiant.Nom;
                this.StudentCheckBox.BindingContext = viewModel.etudiantStatus;
            }
            else
            {
                this.studentFrame.IsVisible = false;
                DisplayAlert("Error", "No student found", "OK");
            }
        }
    }


    private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        var checkbox = (sender as CheckBox);
        etudiantAbsentModels = new List<EtudiantAbsentModel>();
        Console.WriteLine("Checkbox: " + viewModel.etudiantStatus.isPresent);

    }

    private async Task IncrementProgressBarAndSaveData()
    {
        double progress = 0;
        double targetProgress = 0.5;
        const int animationDurationSeconds = 1;
        double increment = 0.01;
        double animationStep = targetProgress / (animationDurationSeconds * (1.0 / increment));
        viewModel.isLoading = true;

        while (progress < targetProgress || viewModel.isLoading)
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
        
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
                IncrementProgressBarAndSaveData();
                return false;
        });
        

    }
}