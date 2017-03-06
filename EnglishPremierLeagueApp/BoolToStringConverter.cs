using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace EnglishPremierLeagueApp
{
    public class BoolToStringConverter<T> : IValueConverter
    {
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return FalseValue;
            }
            return (bool) value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value?.Equals(TrueValue) ?? false;
    }

    public class BoolToStringConverter : BoolToStringConverter<String> { }
}