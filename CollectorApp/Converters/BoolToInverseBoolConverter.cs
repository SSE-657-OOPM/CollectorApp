using System;
using Windows.UI.Xaml.Data;

namespace CollectorApp.Converters
{
    /// <summary>
    /// Converts boolean values to their inverse.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Data.IValueConverter" />
    class BoolToInverseBoolConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Target must be of type bool.</exception>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(bool))
            {
                throw new InvalidOperationException("Target must be of type bool.");
            }
            return !(bool)value;
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
