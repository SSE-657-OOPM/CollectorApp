using System.Collections.ObjectModel;
using System.Linq;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing users of the app.
    /// </summary>
    public class User
    {
        /// <summary>
        /// The collections defined by the user.
        /// </summary>
        public ObservableCollection<CollectionRecord> Collections;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Collections = new ObservableCollection<CollectionRecord>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Adds the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void AddCollection(string name, string description, Priority priority, Category category)
        {
            if (!Collections.Any(c => c.Name == name))
            {
                if (!string.IsNullOrWhiteSpace(description))
                {
                    Collections.Add(new CollectionRecord(name, description, priority, category));
                }
                else
                {
                    Collections.Add(new CollectionRecord(name, priority, category));
                }
            }
        }

        /// <summary>
        /// Deletes the collection.
        /// </summary>
        /// <param name="collectionRecord">The collection record.</param>
        public void DeleteCollection(CollectionRecord collectionRecord)
        {
            Collections.Remove(collectionRecord);
        }

        /// <summary>
        /// Updates the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void UpdateCollection(CollectionRecord collection, string name, 
            string description, Priority priority, Category category)
        {
            if (Collections.FirstOrDefault(c => c.Equals(collection)) != null)
            {
                Collections.FirstOrDefault(c => c.Equals(collection))
                    .Update(name, description, priority, category);
            }
        }

        /// <summary>
        /// Sorts the collections.
        /// </summary>
        /// <param name="sortParameter">The sort parameter.</param>
        public void SortCollections(Record.SortParameter sortParameter)
        {
            if (sortParameter == Record.SortParameter.Priority)
            {
                Collections = new ObservableCollection<CollectionRecord>(
                    Collections.OrderByDescending(c => c.Priority));
            }
            else if (sortParameter == Record.SortParameter.Name)
            {
                Collections = new ObservableCollection<CollectionRecord>(
                    Collections.OrderBy(c => c.Name));
            }
        }

        /// <summary>
        /// Searches the collections.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public ObservableCollection<CollectionRecord> SearchCollections(string keyword)
        {
            var matchingItems = new ObservableCollection<CollectionRecord>(
                Collections.Where(c => c.Name.ToLower().Contains(keyword.ToLower())));
            return matchingItems;
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
