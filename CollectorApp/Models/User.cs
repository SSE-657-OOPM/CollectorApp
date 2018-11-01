using System.Collections.Generic;
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
        /// Different methods of sorting collections.
        /// </summary>
        enum SortParameter
        {
            Priority,
            Name
        }

        /// <summary>
        /// The categories that can be used by the user.
        /// </summary>
        //public List<CategoryRecord> Categories;

        /// <summary>
        /// The collections defined by the user.
        /// </summary>
        public ObservableCollection<CollectionRecord> Collections;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            //Categories = new List<CategoryRecord>();
            Collections = new ObservableCollection<CollectionRecord>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Adds the collection.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        public void AddCollection(string name, string description, int priorityLevel=0)
        {
        //    if (!string.IsNullOrWhiteSpace(description))
        //    {
        //        Collections.Add(new CollectionRecord(name, description, priorityLevel));
        //    }
        //    else
        //    {
        //        Collections.Add(new CollectionRecord(name, priorityLevel));
        //    }
        }

        /// <summary>
        /// Deletes the collection.
        /// </summary>
        /// <param name="collectionRecord">The collection record.</param>
        //public void DeleteCollection(CollectionRecord collectionRecord)
        //{
        //    var categoriesWithCollection = Categories.Where(c => c.Collections.Contains(collectionRecord.Name));
        //    if (categoriesWithCollection.Any())
        //    {
        //        foreach (var category in categoriesWithCollection)
        //        {
        //            category.Collections.Remove(collectionRecord.Name);
        //        }
        //    }
        //    Collections.Remove(collectionRecord);
        //}

        /// <summary>
        /// Updates the collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="priorityLevel">The priority level.</param>
        //public void UpdateCollection(CollectionRecord collection, string name, 
        //    string description, int priorityLevel)
        //{
        //    var categoriesWithCollection = Categories.Where(c => c.Collections.Contains(collection.Name));
        //    if (categoriesWithCollection.Any())
        //    {
        //        foreach (var category in categoriesWithCollection)
        //        {
        //            category.Collections.Remove(collection.Name);
        //            category.AddCollection(name);
        //        }
        //    }
        //    if (Collections.FirstOrDefault(c => c.Equals(collection)) != null)
        //    {
        //        Collections.FirstOrDefault(c => c.Equals(collection))
        //            .Update(name, description, priorityLevel);
        //    }
        //}

        /// <summary>
        /// Sorts the items.
        /// </summary>
        /// <param name="sortParameter">The sort parameter.</param>
        public void SortItems(int sortParameter)
        {
            var sortParam = (SortParameter)sortParameter;
            if (sortParam == SortParameter.Priority)
            {
                Collections = new ObservableCollection<CollectionRecord>(
                    Collections.OrderByDescending(c => c.Priority));
            }
            else if (sortParam == SortParameter.Name)
            {
                Collections = new ObservableCollection<CollectionRecord>(
                    Collections.OrderBy(c => c.Name));
            }
        }

        /// <summary>
        /// Searches the items.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// <returns></returns>
        public ObservableCollection<CollectionRecord> SearchItems(string keyword)
        {
            var matchingItems = new ObservableCollection<CollectionRecord>(
                Collections.Where(c => c.Name.Contains(keyword)));
            return matchingItems;
        }

        /// <summary>
        /// Adds to category.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <param name="category">The category.</param>
        //public void AddToCategory(CollectionRecord collection, CategoryRecord category)
        //{
        //    var collectionName = collection.Name;
        //    if (Categories.FirstOrDefault(c => c.Equals(category)) != null)
        //    {
        //        //Categories.FirstOrDefault(c => c.Equals(category))
        //        //    .AddCollection(collectionName);
        //    }
        //}
    }
}
