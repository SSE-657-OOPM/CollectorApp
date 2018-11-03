using System.Collections.ObjectModel;
using System.Linq;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing a collection.
    /// </summary>
    /// <seealso cref="CollectorApp.Models.Record" />
    public class CollectionRecord : Record
    {
        private const string DEFAULT_COLLECTION_DESCRIPTION = "No description.";

        /// <summary>
        /// The items in the collection record.
        /// </summary>
        public ObservableCollection<ItemRecord> Items;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public CollectionRecord(string name, Priority priority, Category category = null)
        {
            Name = name;
            Description = DEFAULT_COLLECTION_DESCRIPTION;
            Priority = priority ?? Priority.GetPriority(Priority.PriorityLevel.Normal);
            Category = category;
            Items = new ObservableCollection<ItemRecord>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public CollectionRecord(string name, string description, Priority priority, Category category = null)
        {
            Name = name;
            Description = description;
            Priority = priority ?? Priority.GetPriority(Priority.PriorityLevel.Normal);
            Category = category;
            Items = new ObservableCollection<ItemRecord>();
        }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description of the collection.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category of the collection.
        /// </value>
        public Category Category { get; set; }

        /// <summary>
        /// Updates the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priority">The priority.</param>
        /// <param name="category">The category.</param>
        public void Update(string name, string description, Priority priority, Category category)
        {
            Name = name;
            Description = description;
            Priority = priority;
            Category = category;
        }

        /// <summary>
        /// Adds the item to the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void AddItem(string name, Priority priority)
        {
            if (!Items.Any(i => i.Name == name))
            {
                Items.Add(new ItemRecord(name, priority));
            }
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
        public void UpdateItem(ItemRecord item, string name, Priority priority)
        {
            if (Items.FirstOrDefault(c => c.Equals(item)) != null)
            {
                Items.FirstOrDefault(c => c.Equals(item))
                    .Update(name, priority);
            }
        }

        /// <summary>
        /// Sorts the items.
        /// </summary>
        /// <param name="sortParameter">The sort parameter.</param>
        public void SortItems(SortParameter sortParameter)
        {
            if (sortParameter == SortParameter.Priority)
            {
                Items = new ObservableCollection<ItemRecord>(Items.OrderByDescending(i => i.Priority));
            }
            else if (sortParameter == SortParameter.Name)
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
                Items.Where(i => i.Name.ToLower().Contains(keyword.ToLower())));
            return matchingItems;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="CollectionRecord"/> class from being created.
        /// </summary>
        private CollectionRecord() { }
    }
}
