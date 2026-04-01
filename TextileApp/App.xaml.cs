using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using TextileApp.Data;
using TextileApp.MVVM.ViewModels;
using TextileApp.Services;

namespace TextileApp
{
    public partial class App : Application
    {
        private Window? _window;
        private IServiceProvider? _serviceProvider;

        public App()
        {
            InitializeComponent();
            InitializeServices();
        }

        private void InitializeServices()
        {
            var services = new ServiceCollection();

            // Строка подключения к базе данных
            const string connectionString = "Server=ARUMI\\SQLEXPRESS;Database=TextileEnterprise;Trusted_Connection=true;TrustServerCertificate=True;";

            services.AddDbContext<TextileDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddTransient<DashboardViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public T? GetService<T>() where T : class
        {
            return _serviceProvider?.GetService(typeof(T)) as T;
        }

        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            _window = new MainWindow();
            _window.Activate();
        }
    }
}
