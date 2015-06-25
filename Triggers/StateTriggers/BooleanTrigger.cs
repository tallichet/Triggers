using Windows.UI.Xaml;

namespace Triggers.StateTriggers
{
    public class BooleanTrigger : StateTriggerBase
    {
        public bool Not
        {
            get { return (bool)GetValue(NotProperty); }
            set { SetValue(NotProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Not.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NotProperty =
            DependencyProperty.Register("Not", typeof(bool), typeof(BooleanTrigger), new PropertyMetadata(false, IsActivePropertyChanged));


        public bool? IsActive
        {
            get { return (bool?)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsActive.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool?), typeof(BooleanTrigger), new PropertyMetadata(null, IsActivePropertyChanged));

        private static void IsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var trigger = d as BooleanTrigger;
            var isActive = (trigger.IsActive ?? false) ^ trigger.Not;
            trigger.SetActive(isActive);
        }
    }
}
