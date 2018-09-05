namespace CollectorApp.Models
{
    /// <summary>
    /// Abstract class defining all commonalities among records.
    /// </summary>
    /// <seealso cref="CollectorApp.Models.BindableBase" />
    public abstract class Record : BindableBase
    {
        /// <summary>
        /// The name of the record.
        /// </summary>
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Name;
    }
}
