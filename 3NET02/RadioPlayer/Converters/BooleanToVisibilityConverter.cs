using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RadioPlayer.Converters
{
    public class BooleanToVisibilityConverter : DependencyObject, IValueConverter
    {
        public bool Reverse
        {
            get { return (bool) GetValue(CurrentUserProperty); }
            set { SetValue(CurrentUserProperty, value); }
        }
        public static readonly DependencyProperty CurrentUserProperty =
            DependencyProperty.Register("Reverse", typeof (bool), 
                typeof (BooleanToVisibilityConverter), new PropertyMetadata(false));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool visibility = (bool)value;
            if (Reverse) visibility = !visibility;

            if (visibility)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
