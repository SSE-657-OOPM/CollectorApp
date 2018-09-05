using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CollectorApp.Models
{
    /// <summary>
    /// Abstract class to be implemented by all objects requiring
    /// property changed events to be raised.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propVal">The property value.</param>
        /// <param name="setVal">The set value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected virtual bool SetProperty<T>(ref T propVal, T setVal,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(propVal, setVal)) return false;
            propVal = setVal;
            RaisePropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
