using FluentAvalonia.UI.Controls;
using IBinding = BD.Common.Converters.Abstractions.IBinding;

namespace BD.WTTS.Converters;

public class ResourceKeyValueConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            if (string.Equals(parameter?.ToString(), "fonticon", StringComparison.OrdinalIgnoreCase))
                return App.Instance.FindResource("Unknown");
            else
                return null;
        }
        if (value is string key)
        {
            var v = App.Instance.FindResource(key);
            if ((v is null || v == AvaloniaProperty.UnsetValue) && string.Equals(parameter?.ToString(), "fonticon", StringComparison.OrdinalIgnoreCase))
                return App.Instance.FindResource("Unknown");
            return v;
        }
        return ((IBinding)this).DoNothing;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return ((IBinding)this).DoNothing;
    }
}