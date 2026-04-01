using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TextileApp.MVVM.ViewModels;

namespace TextileApp.MVVM.Views
{
    public sealed partial class Dashboard : Page
    {
        public DashboardViewModel ViewModel { get; }

        public Dashboard()
        {
            InitializeComponent();
            var app = App.Current as App;
            ViewModel = app?.GetService<DashboardViewModel>() ?? new DashboardViewModel(null);
            DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadDataCommand.ExecuteAsync(null);
        }
    }
}


