using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ButtonStyleGallery
{
    public class CommonStatesIndicator : ContentControl
    {
        /// <summary>
        ///     标识 AttachedElement 依赖属性。
        /// </summary>
        public static readonly DependencyProperty AttachedElementProperty =
            DependencyProperty.Register("AttachedElement", typeof(Control), typeof(CommonStatesIndicator), new PropertyMetadata(null, OnAttachedElementChanged));

        /// <summary>
        ///     获取或设置AttachedElement的值
        /// </summary>
        public Control AttachedElement
        {
            get { return (Control)GetValue(AttachedElementProperty); }
            set { SetValue(AttachedElementProperty, value); }
        }

        private static void OnAttachedElementChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var target = obj as CommonStatesIndicator;
            var oldValue = (Control)args.OldValue;
            var newValue = (Control)args.NewValue;
            if (oldValue != newValue)
                target.OnAttachedElementChanged(oldValue, newValue);
        }

        protected virtual void OnAttachedElementChanged(Control oldValue, Control newValue)
        {
            if (newValue == null)
                return;

            var group = VisualStateManager.GetVisualStateGroups(newValue).FirstOrDefault(g => g.Name == "CommonStates");
            group.CurrentStateChanged += (s, e) =>
            {
                Content = e.NewState.Name;
            };

            if (group.CurrentState != null)
                Content = group.CurrentState.Name;
        }
    }
}