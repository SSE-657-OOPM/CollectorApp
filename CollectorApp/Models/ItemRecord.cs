namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing an item.
    /// </summary>
    /// <seealso cref="CollectorApp.Models.Record" />
    public class ItemRecord : Record
    {
        /// <summary>
        /// Value specifying if item has been collected.
        /// </summary>
        private bool _isCollected;
        public bool IsCollected
        {
            get => _isCollected;
            set => SetProperty(ref _isCollected, value);
        }
    }
}
