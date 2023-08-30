using System.Windows;
using System.Windows.Controls;

namespace CustomControlsLibrary
{
   public class SimpleLoadingSpinner : Control
    {
        public static readonly DependencyProperty IsLoadingProperty = DependencyProperty.Register(
            nameof(IsLoading), typeof(bool), 
            typeof(SimpleLoadingSpinner), new PropertyMetadata(false));

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set => SetValue(IsLoadingProperty, value);
        }
        
        static SimpleLoadingSpinner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SimpleLoadingSpinner),
                new FrameworkPropertyMetadata(typeof(SimpleLoadingSpinner)));
        }
    }
}