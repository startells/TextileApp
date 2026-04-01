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
        private readonly IOrderService? _orderService;

        [ObservableProperty]
        public partial string Title { get; set; } = "Панель управления";

        [ObservableProperty]
        public partial int MaterialsCount { get; set; }

        [ObservableProperty]
        public partial int ActiveOrdersCount { get; set; }

        [ObservableProperty]
        public partial bool IsLoading { get; set; }

        public DashboardViewModel(IMaterialService? materialService, IOrderService? orderService)
        {
            _materialService = materialService;
            _orderService = orderService;
        }

        [RelayCommand]
        public async Task LoadData()
        {
            if (_materialService == null || _orderService == null)
            {
                Debug.WriteLine("Services are not available. Cannot load data.");
                return;
            }

            try
            {
                IsLoading = true;
                MaterialsCount = await _materialService.GetMaterialCountAsync();
                ActiveOrdersCount = await _orderService.GetActiveOrderCountAsync();
                Debug.WriteLine($"Loaded material count: {MaterialsCount}");
                Debug.WriteLine($"Loaded active orders count: {ActiveOrdersCount}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}


