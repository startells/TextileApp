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
        private readonly IClientService? _clientService;

        [ObservableProperty]
        public partial string Title { get; set; } = "Панель управления";

        [ObservableProperty]
        public partial int MaterialsCount { get; set; }

        [ObservableProperty]
        public partial int ActiveOrdersCount { get; set; }

        [ObservableProperty]
        public partial int ClientsCount { get; set; }

        [ObservableProperty]
        public partial bool IsLoading { get; set; }

        public DashboardViewModel(IMaterialService? materialService, IOrderService? orderService, IClientService? clientService)
        {
            _materialService = materialService;
            _orderService = orderService;
            _clientService = clientService;
        }

        [RelayCommand]
        public async Task LoadData()
        {
            if (_materialService == null || _orderService == null || _clientService == null)
            {
                Debug.WriteLine("Services are not available. Cannot load data.");
                return;
            }

            try
            {
                IsLoading = true;
                MaterialsCount = await _materialService.GetMaterialCountAsync();
                ActiveOrdersCount = await _orderService.GetActiveOrderCountAsync();
                ClientsCount = await _clientService.GetClientCountAsync();
                Debug.WriteLine($"Loaded material count: {MaterialsCount}");
                Debug.WriteLine($"Loaded active orders count: {ActiveOrdersCount}");
                Debug.WriteLine($"Loaded clients count: {ClientsCount}");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}


