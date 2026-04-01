using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TextileApp.Services;
using TextileApp.MVVM.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace TextileApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private NavigationService _navigationService;

        public MainWindow()
        {
            InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);

            _navigationService = new NavigationService(ContentFrame);

            // Регистрируем все страницы
            _navigationService.RegisterPage("dashboard", typeof(Dashboard));
            _navigationService.RegisterPage("orders", typeof(Dashboard));
            _navigationService.RegisterPage("employees", typeof(Dashboard));
            _navigationService.RegisterPage("products", typeof(Dashboard));
            _navigationService.RegisterPage("materials", typeof(Dashboard));
            _navigationService.RegisterPage("accessories", typeof(Dashboard));

            // Навигируем на первую страницу по умолчанию
            _navigationService.Navigate("dashboard");

            // Подключаем обработчик выбора пункта меню
            NavView.ItemInvoked += NavView_ItemInvoked;
        }

        // Toggle the NavigationView pane open or closed when the TitleBar button is clicked.
        private void TitleBar_PaneToggleRequested(TitleBar sender, object args)
        {
            NavView.IsPaneOpen = !NavView.IsPaneOpen;
        }

        // Navigate back when the TitleBar back button is clicked.
        private void TitleBar_BackRequested(TitleBar sender, object args)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }

        // Hide the pane toggle button in the TitleBar when NavigationView switches to Top mode,
        // since the pane isn't applicable in that layout.
        private void NavView_DisplayModeChanged(NavigationView sender,
            NavigationViewDisplayModeChangedEventArgs args)
        {
            TitleBar.IsPaneToggleButtonVisible =
                sender.PaneDisplayMode != NavigationViewPaneDisplayMode.Top;
        }

        // Обработка выбора пункта меню
        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                return;
            }

            var selectedItem = args.InvokedItem as string;

            switch (selectedItem)
            {
                case "Панель управления":
                    _navigationService.Navigate("dashboard");
                    break;
                case "Заказы":
                    _navigationService.Navigate("orders");
                    break;
                case "Сотрудники":
                    _navigationService.Navigate("employees");
                    break;
                case "Продукция":
                    _navigationService.Navigate("products");
                    break;
                case "Материалы":
                    _navigationService.Navigate("materials");
                    break;
                case "Фурнитура":
                    _navigationService.Navigate("accessories");
                    break;
            }
        }
    }
}
