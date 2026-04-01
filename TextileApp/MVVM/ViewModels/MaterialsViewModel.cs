using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TextileApp.Data.Entities;
using TextileApp.Services;

namespace TextileApp.MVVM.ViewModels
{
    public partial class MaterialsViewModel : ObservableObject
    {
        private readonly IMaterialService? _materialService;

        [ObservableProperty]
        public partial string Title { get; set; }

        [ObservableProperty]
        public partial ObservableCollection<Material> Materials { get; set; }

        [ObservableProperty]
        public partial Material? SelectedMaterial { get; set; }

        [ObservableProperty]
        public partial bool IsLoading { get; set; }

        public MaterialsViewModel(IMaterialService? materialService)
        {
            _materialService = materialService;
            Title = "Материалы";
            Materials = new();
        }

        [RelayCommand]
        public async Task LoadMaterials()
        {
            if (_materialService == null)
            {
                Debug.WriteLine("MaterialService is not available. Cannot load materials.");
                return;
            }

            try
            {
                IsLoading = true;
                var materials = await _materialService.GetMaterialsAsync();
                Materials.Clear();
                foreach (var material in materials)
                {
                    Materials.Add(material);
                }
                Debug.WriteLine($"Loaded {materials.Count} materials");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading materials: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        public void AddMaterial()
        {
            Debug.WriteLine("Add material action");
        }

        [RelayCommand]
        public void EditMaterial()
        {
            if (SelectedMaterial == null)
            {
                Debug.WriteLine("No material selected for editing");
                return;
            }

            Debug.WriteLine($"Edit material: {SelectedMaterial.Name}");
        }

        [RelayCommand]
        public void DeleteMaterial()
        {
            if (SelectedMaterial == null)
            {
                Debug.WriteLine("No material selected for deletion");
                return;
            }

            Debug.WriteLine($"Delete material: {SelectedMaterial.Name}");
        }
    }
}
