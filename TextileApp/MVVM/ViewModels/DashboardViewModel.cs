using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TextileApp.Services;

namespace TextileApp.MVVM.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        private readonly IMaterialService? _materialService;

        [ObservableProperty]
        public partial string Title { get; set; } = "Панель управления";

        [ObservableProperty]
        public partial int MaterialsCount { get; set; }

        [ObservableProperty]
        public partial bool IsLoading { get; set; }

        public DashboardViewModel(IMaterialService? materialService)
        {
            _materialService = materialService;
        }

        [RelayCommand]
        public async Task LoadData()
        {
            if (_materialService == null)
            {
                Debug.WriteLine("MaterialService is not available. Cannot load data.");
                return;
            }

            try
            {
                IsLoading = true;
                MaterialsCount = await _materialService.GetMaterialCountAsync();
                Debug.WriteLine($"Loaded material count: {MaterialsCount}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}


