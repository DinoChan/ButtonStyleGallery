using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace ButtonStyleGallery
{
    /// <summary>
    ///     可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnVisualStateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ButtonsPanel == null)
                return;

            var comboBox = sender as ComboBox;

            var selectedItem = comboBox?.SelectedItem as ComboBoxItem;
            if (selectedItem == null)
                return;

            foreach (var item in ButtonsPanel.Children.OfType<Control>())
                VisualStateManager.GoToState(item, selectedItem.Content as string, true);
        }

      
    }
}