using System.Collections.ObjectModel;

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
        /// The categories defined by the user.
        /// </summary>
        public ObservableCollection<CategoryRecord> Categories;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            Collections = new ObservableCollection<CollectionRecord>();
            Categories = new ObservableCollection<CategoryRecord>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
