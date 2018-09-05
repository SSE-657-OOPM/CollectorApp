using System;
using Windows.UI.Xaml.Data;

namespace CollectorApp.Converters
{
    /// <summary>
    /// Class to convert bool types to nullable bool types.
    /// </summary>
    public class BoolToNullableBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, 
            object parameter, string language) => value;

        /// <summary>
        /// Converts back.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            bool defaultValue = parameter != null ?
                (bool)parameter : false;
            bool? val = (bool?)value;
            return val ?? defaultValue;
        }
    }
}
