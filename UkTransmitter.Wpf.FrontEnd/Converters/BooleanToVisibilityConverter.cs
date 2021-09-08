using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using UkTransmitter.Wpf.FrontEnd.Infrastructure;

namespace UkTransmitter.Wpf.FrontEnd.Converters
{
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}