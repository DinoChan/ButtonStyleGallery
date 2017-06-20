using System.Numerics;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Microsoft.Xaml.Interactivity;

namespace ButtonStyleGallery
{
    public class PointerLightBehavior : Behavior<TextBlock>
    {
        private PointLight _pointLight;

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PointerMoved += OnPointerMoved;
            AssociatedObject.PointerExited += OnPointerExited;

            var compositor = ElementCompositionPreview.GetElementVisual(AssociatedObject).Compositor;

            var text = ElementCompositionPreview.GetElementVisual(AssociatedObject);

            _pointLight = compositor.CreatePointLight();
            _pointLight.Color = Colors.White;
            _pointLight.CoordinateSpace = text;
            _pointLight.Targets.Add(text);

            _pointLight.Offset = new Vector3(-(float) 1000, (float) AssociatedObject.ActualHeight / 2, (float) AssociatedObject.FontSize);
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var position = e.GetCurrentPoint(AssociatedObject);
            //starts out to the left; vertically centered; light's z-offset is related to fontsize
            _pointLight.Offset = new Vector3((float) position.Position.X, (float) position.Position.Y, (float) (AssociatedObject.FontSize / 1.5));
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            _pointLight.Offset = new Vector3(-(float) AssociatedObject.ActualWidth*5, (float) AssociatedObject.ActualHeight / 2, (float) AssociatedObject.FontSize);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PointerMoved -= OnPointerMoved;
            AssociatedObject.PointerExited -= OnPointerExited;
        }
    }
}