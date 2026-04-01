using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;

namespace TextileApp.Services
{
    public class NavigationService
    {
        private readonly Frame _frame;
        private readonly Dictionary<string, Type> _pages;

        public NavigationService(Frame frame)
        {
            _frame = frame;
            _pages = new Dictionary<string, Type>();
        }

        public void RegisterPage(string key, Type pageType)
        {
            _pages[key] = pageType;
        }

        public void Navigate(string pageKey)
        {
            if (_pages.TryGetValue(pageKey, out var pageType))
            {
                _frame.Navigate(pageType);
            }
        }

        public bool CanGoBack => _frame.CanGoBack;

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
