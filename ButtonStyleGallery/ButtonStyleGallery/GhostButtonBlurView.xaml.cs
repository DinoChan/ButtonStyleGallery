using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace ButtonStyleGallery
{
    public sealed partial class GhostButtonBlurView : UserControl
    {
        public GhostButtonBlurView()
        {
            this.InitializeComponent();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Blur.Value = 1;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Blur.Value = 0;
        }
    }
}
