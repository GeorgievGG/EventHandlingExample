using AuthControl.Models;
using EventHandlingExample.ViewModels;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EventHandlingExample
{
    public sealed partial class EntryScreen : Page
    {
        public EntryScreen()
        {
            this.InitializeComponent();

            ViewModel = new EntryScreenViewModel();
        }

        public EntryScreenViewModel ViewModel { get; }

        private async void OnShowAuthControlButtonClick(object sender, RoutedEventArgs e)
        {
            await AuthContentDialog.ShowAsync();
        }

        // TODO: EventHandler
    }
}
