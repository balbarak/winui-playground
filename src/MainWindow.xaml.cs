using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PlaygroundApp.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PlaygroundApp
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var page = new AnimationPage();
            SetContent(page);
        }

        private void OnMenuItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {

            }
            else if (args.InvokedItemContainer != null)
            {
                
                var tag = args.InvokedItemContainer.Tag.ToString();
                var type = Type.GetType(tag);

                var page = Activator.CreateInstance(type) as Page;


                SetContent(page);

            }
        }

        private void SetSelectedMenu(Type type)
        {
            foreach (var item in NavigationController.MenuItems)
            {
                if (item is NavigationViewItem menu)
                {
                    if (menu.Tag?.ToString() == type.FullName)
                    {
                        NavigationController.SelectedItem = menu;

                        return;
                    }
                }
            }
        }

        private void SetContent(Page page)
        {
            NavigationController.Content = page;

            SetSelectedMenu(page.GetType());
        }
    }
}
