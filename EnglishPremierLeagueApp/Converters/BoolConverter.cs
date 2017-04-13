using System;
using System.Globalization;
using System.Windows.Data;

namespace EnglishPremierLeagueApp.Converters
{
    public class BoolConverter<T> : IValueConverter
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

    public class BoolToStringConverter : BoolConverter<string> { }
}