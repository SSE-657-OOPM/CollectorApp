namespace CollectorApp.Models
{
    /// <summary>
    /// Abstract class defining all commonalities among records.
    /// </summary>
    public abstract class Record
    {
        /// <summary>
        /// Parameter by which to sort records.
        /// </summary>
        public enum SortParameter
        {
            Priority,
            Name
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the record.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        /// <value>
        /// The priority of the record.
        /// </value>
        public Priority Priority { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Name;
    }
}
