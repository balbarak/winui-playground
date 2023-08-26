using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PlaygroundApp
{
    public sealed class BoxControl : ContentControl
    {

        public static readonly DependencyProperty IsToggleProperty =
            DependencyProperty.Register(nameof(IsToggle), typeof(bool), typeof(BoxControl), new PropertyMetadata(false, OnIsToggledChanged));



        public bool IsToggle { get => (bool)GetValue(IsToggleProperty); set => SetValue(IsToggleProperty, value); }


        public BoxControl()
        {
            this.DefaultStyleKey = typeof(BoxControl);
        }

        private static void OnIsToggledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as BoxControl;

            if ((bool)e.NewValue)
                VisualStateManager.GoToState(control, "ToggleState", true);
            else
                VisualStateManager.GoToState(control, "NotToggleState", true);
        }
    }
}
