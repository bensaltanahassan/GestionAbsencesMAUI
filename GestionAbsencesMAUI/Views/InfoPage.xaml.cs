using GestionAbsencesMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace GestionAbsencesMAUI.Views
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
            BindingContext = new InfoPageViewModel();
            MessagingCenter.Subscribe<InfoPageViewModel>(this, "ShowFramesMessage", (sender) =>
            {
                
                ResultLabelFrame.IsVisible = true;
                ResultLabel2Frame.IsVisible = true;
            });
        }
    }
}
