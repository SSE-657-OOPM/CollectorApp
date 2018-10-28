namespace CollectorApp.Models
{
    public class Priority
    {
        /// <summary>
        /// Different levels of priority.
        /// </summary>
        public enum PriorityLevel
        {
            Low,
            Normal,
            Important,
            Critical
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Priority"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        public Priority(int level)
        {
            Level = (PriorityLevel)level;
        }

        /// <summary>
        /// Gets or sets the level.
        /// </summary>
        public PriorityLevel Level { get; set; }
    }
}
