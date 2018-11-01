namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing an item in a collection.
    /// </summary>
    public class ItemRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public ItemRecord(string name, int priorityLevel=0)
        {
            Name = name;
            //Priority = new Priority(priorityLevel);
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is collected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is collected; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollected { get; set; } = false;

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        //public void Update(string name, int priorityLevel)
        //{
        //    Name = name;
        //    Priority = new Priority(priorityLevel);
        //}

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Name;

        /// <summary>
        /// Prevents a default instance of the <see cref="ItemRecord"/> class from being created.
        /// </summary>
        private ItemRecord() { }
    }
}
