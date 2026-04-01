using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using TextileApp.MVVM.ViewModels;

namespace TextileApp.MVVM.Views
{
    public sealed partial class Materials : Page
    {
        public MaterialsViewModel ViewModel { get; }

        public Materials()
        {
            InitializeComponent();
            var app = App.Current as App;
            ViewModel = app?.GetService<MaterialsViewModel>() ?? new MaterialsViewModel(null);
            DataContext = this;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            await ViewModel.LoadMaterialsCommand.ExecuteAsync(null);
        }
    }
}
