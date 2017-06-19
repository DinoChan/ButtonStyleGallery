using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Composition;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Toolkit.Uwp.UI.Animations.Effects;

namespace ButtonStyleGallery.Effects
{
   

    public class Brightness : AnimationEffect
    {
        /// <summary>
        /// Gets a value indicating whether Saturation is supported.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is supported; otherwise, <c>false</c>.
        /// </value>
        public override bool IsSupported
            => ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 3);

        /// <summary>
        /// Gets the name of the effect.
        /// </summary>
        /// <value>
        /// The name of the effect.
        /// </value>
        public override string EffectName { get; } = "Brightness";

        /// <summary>
        /// Applies the effect.
        /// </summary>
        /// <returns>
        /// An array of strings of the effect properties to change.
        /// </returns>
        public override string[] ApplyEffect()
        {
            var saturationEffect = new SaturationEffect
            {
                Saturation = 1f,
                Name = EffectName,
                Source = new CompositionEffectSourceParameter("source")
            };

            var propertyToChange = $"{EffectName}.Brightness";
            var propertiesToAnimate = new[] { propertyToChange };

            EffectBrush = Compositor.CreateEffectFactory(saturationEffect, propertiesToAnimate).CreateBrush();
            EffectBrush.SetSourceParameter("source", Compositor.CreateBackdropBrush());

            return propertiesToAnimate;
        }
    }
}
