using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Animations;
using Microsoft.Toolkit.Uwp.UI.Animations.Behaviors;

namespace ButtonStyleGallery
{
    public class BrightnessBehavior : BehaviorBase<UIElement>
    {
        private CompositionEffectBrush _brush;

        /// <summary>
        /// 获取或设置Value的值
        /// </summary>  
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// 标识 Value 依赖属性。
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(BrightnessBehavior), new PropertyMetadata(0d, OnValueChanged));

        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            BrightnessBehavior target = obj as BrightnessBehavior;
            double oldValue = (double)args.OldValue;
            double newValue = (double)args.NewValue;
            if (oldValue != newValue)
                target.OnValueChanged(oldValue, newValue);
        }

        protected virtual void OnValueChanged(double oldValue, double newValue)
        {
            System.Numerics.Vector2 whitePoint;
            if (newValue < 0)
                whitePoint = new System.Numerics.Vector2(1 + (float)newValue, 1);
            else
                whitePoint = new System.Numerics.Vector2(1, 1 - (float)newValue);

            _brush.Properties.InsertVector2("BrightnessEffect.WhitePoint", whitePoint);
        }

        protected override void OnAssociatedObjectLoaded()
        {
            base.OnAssociatedObjectLoaded();
            var visual = ElementCompositionPreview.GetElementVisual(AssociatedObject);
            var compositor = visual.Compositor;

            var brightnessEffect = new BrightnessEffect
            {
                Name = "BrightnessEffect",
                Source = new CompositionEffectSourceParameter("source")
            };
            
            var effectFactory = compositor.CreateEffectFactory(brightnessEffect, new[] { "BrightnessEffect.WhitePoint" });
            _brush = effectFactory.CreateBrush();

            _brush.SetSourceParameter("source", compositor.CreateBackdropBrush());

            //_brush.Properties.InsertScalar("BrightnessEffect.WhitePoint", 0f);
        }
    }
}
