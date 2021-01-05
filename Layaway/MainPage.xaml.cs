using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.StartScreen;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Layaway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void CreateSecondaryTile_Click(object sender, RoutedEventArgs e)
        {
            Uri square150x150Logo = new Uri("ms-appx:///Assets/Square150x150Logo-scale-200.png");
            SecondaryTile secondaryTile = new SecondaryTile("tileId", "Testing Tile", $"tileId:{DateTime.Now.ToLocalTime():HH/mm/ss}", square150x150Logo, TileSize.Default);
            bool isPinned = await secondaryTile.RequestCreateAsync();
            
        }

        private async void DeleteSecondaryTile_Click(object sender, RoutedEventArgs e)
        {
            if (SecondaryTile.Exists("tileId"))
            {
                SecondaryTile toBeDeleted = new SecondaryTile("tileId");

                bool isDeleted = await toBeDeleted.RequestDeleteAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            InputPane currentInputPane = InputPane.GetForCurrentView();
            currentInputPane.Showing += OnShowing;
            currentInputPane.Hiding += OnHiding;
        }

        private void OnHiding(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            KeyboardTestResult.Text = "Hiding";
        }

        private void OnShowing(InputPane sender, InputPaneVisibilityEventArgs args)
        {
            KeyboardTestResult.Text = "Showing";
        }
    }
}
