namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing an item in a collection.
    /// </summary>
    /// <seealso cref="CollectorApp.Models.Record" />
    public class ItemRecord : Record
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public ItemRecord(string name, Priority priority)
        {
            Name = name;
            Priority = priority;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is collected; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollected { get; set; } = false;

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update(string name, Priority priority)
        {
            Name = name;
            Priority = priority;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="ItemRecord"/> class from being created.
        /// </summary>
        private ItemRecord() { }
    }
}
