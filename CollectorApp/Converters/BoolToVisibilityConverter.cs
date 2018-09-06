using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace CollectorApp.Converters
{
    /// <summary>
    /// Class to allow appropriate object display in list views.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Data.IValueConverter" />
    public class BoolToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// Converts back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return false;
        }
    }
}
