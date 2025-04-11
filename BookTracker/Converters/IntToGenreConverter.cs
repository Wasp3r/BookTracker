using System.Globalization;
using BookTracker.Models;

namespace BookTracker.Converters;

public class IntToGenreConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
            return null;
        
        return (Genre)(int)value;
    }
}