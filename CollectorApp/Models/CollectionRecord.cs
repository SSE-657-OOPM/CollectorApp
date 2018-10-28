using System.Collections.ObjectModel;
using System.Linq;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing a collection.
    /// </summary>
    public class CollectionRecord
    {
        /// <summary>
        /// Different methods of sorting items.
        /// </summary>
        enum SortParameter
        {
            Priority,
            Name
        }

        /// <summary>
        /// The items in the collection record.
        /// </summary>
        public ObservableCollection<ItemRecord> Items;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public CollectionRecord(string name, int priorityLevel=0)
        {
            Name = name;
            Priority = new Priority(priorityLevel);
            Items = new ObservableCollection<ItemRecord>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public CollectionRecord(string name, string description, int priorityLevel=0)
        {
            Name = name;
            Description = description;
            Priority = new Priority(priorityLevel);
            Items = new ObservableCollection<ItemRecord>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the priority.
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void Update(string name, string description, int priorityLevel)
        {
            Name = name;
            Description = description;
            Priority = new Priority(priorityLevel);
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void AddItem(string name, int priorityLevel=0)
        {
            Items.Add(new ItemRecord(name, priorityLevel));
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void DeleteItem(ItemRecord item)
        {
            Items.Remove(item);
        }

        /// <summary>
        /// Updates the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void UpdateItem(ItemRecord item, string name, int priorityLevel)
        {
            if (Items.FirstOrDefault(c => c.Equals(item)) != null)
            {
                Items.FirstOrDefault(c => c.Equals(item))
                    .Update(name, priorityLevel);
            }
        }

        /// <summary>
        /// Sorts the items.
        /// </summary>
        /// <param name="sortParameter">The sort parameter.</param>
        public void SortItems(int sortParameter)
        {
            var sortParam = (SortParameter)sortParameter;
            if (sortParam == SortParameter.Priority)
            {
                Items = new ObservableCollection<ItemRecord>(Items.OrderByDescending(i => i.Priority));
            }
            else if (sortParam == SortParameter.Name)
            {
                Items = new ObservableCollection<ItemRecord>(Items.OrderBy(i => i.Name));
            }
        }

        /// <summary>
        /// Searches the items.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public ObservableCollection<ItemRecord> SearchItems(string keyword)
        {
            var matchingItems = new ObservableCollection<ItemRecord>(
                Items.Where(i => i.Name.Contains(keyword)));
            return matchingItems;
        }
    }
}
