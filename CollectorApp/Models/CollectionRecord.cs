using System.Collections.ObjectModel;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing a collection.
    /// </summary>
    /// <seealso cref="CollectorApp.Models.Record" />
    public class CollectionRecord : Record
    {
        /// <summary>
        /// The items in the collection record.
        /// </summary>
        public ObservableCollection<ItemRecord> Items;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRecord"/> class.
        /// </summary>
        public CollectionRecord()
        {
            Items = new ObservableCollection<ItemRecord>();
        }
    }
}
