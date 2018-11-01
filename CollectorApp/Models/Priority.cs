using System;
using System.Collections.Generic;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing priorities of collections and items.
    /// </summary>
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
        /// The instances of category records in the application.
        /// </summary>
        private static Dictionary<PriorityLevel, Priority> _instances
            = new Dictionary<PriorityLevel, Priority>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Priority"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        private Priority(PriorityLevel level)
        {
            Level = level;
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <param name="priorityLevel">The priority level.</param>
        /// <returns></returns>
        public static Priority GetPriority(PriorityLevel priorityLevel)
        {
            return _instances[priorityLevel];
        }

        /// <summary>
        /// Gets the priority.
        /// </summary>
        /// <param name="priorityLevel">The priority level.</param>
        /// <returns></returns>
        public static Priority GetPriority(int priorityLevel)
        {
            if (_instances.TryGetValue((PriorityLevel)priorityLevel, out var priority))
            {
                return priority;
            }
            return null;
        }

        /// <summary>
        /// Loads the priority levels.
        /// </summary>
        public static void LoadPriorityLevels()
        {
            foreach (PriorityLevel level in Enum.GetValues(typeof(PriorityLevel)))
            {
                new Priority(level).Store();
            }
        }

        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level of the priority.
        /// </value>
        public PriorityLevel Level { get; }

        /// <summary>
        /// Stores this instance.
        /// </summary>
        private void Store()
        {
            if (!_instances.ContainsKey(Level))
            {
                _instances.Add(Level, this);
            }
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Priority"/> class from being created.
        /// </summary>
        private Priority() { }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Level.ToString();

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            var c = ToString().ToCharArray();
            return c[0];
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() == GetType())
            {
                return ((Priority)obj).Level == Level;
            }
            return false;
        }

        #region Operator Functions

        public static bool operator ==(Priority left, Priority right)
            => ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.Equals(right);
        public static bool operator !=(Priority left, Priority right)
            => !(left == right);
        public static bool operator <(Priority left, Priority right)
            => (int)left.Level < (int)right.Level;
        public static bool operator >(Priority left, Priority right)
            => (int)left.Level > (int)right.Level;

        #endregion
    }
}
