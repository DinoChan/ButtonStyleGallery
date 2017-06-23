using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Animations;

namespace ButtonStyleGallery.Effects
{
    public static class BrightnessAnimationExtensions
    {
        public static Brightness BrightnessEffect { get; } = new Brightness();

        public static AnimationSet Brightness(
            this FrameworkElement associatedObject,
            double value = 0d,
            double duration = 500d,
            double delay = 0d)
        {
            if (associatedObject == null)
            {
                return null;
            }

            var animationSet = new AnimationSet(associatedObject);
            return animationSet.Brightness(value, duration, delay);
        }

        public static AnimationSet Brightness(
            this AnimationSet animationSet,
            double value = 0d,
            double duration = 500d,
            double delay = 0d)
        {
            value = Math.Max(-1, value);
            value = Math.Min(1, value);

            System.Numerics.Vector2 whitePoint;
            if (value < 0)
                whitePoint = new System.Numerics.Vector2(1 + (float)value, 1);
            else
                whitePoint = new System.Numerics.Vector2(1, 1 - (float)value);

            return null;

            //return BrightnessEffect.EffectAnimation(animationSet, whitePoint, duration, delay);
        }
    }
}
