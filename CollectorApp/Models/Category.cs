using System.Collections.Generic;
using System.Xml.Linq;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing categories of collections.
    /// </summary>
    public class Category
    {
        private const string DEFAULT_CATEGORY_RECORD_FILE = "./Resources/CategoryRecords.xml";
        private const string CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME = "Category";
        private const string CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME = "Name";
        private const string CATEGORY_RECORD_XML_CATEGORY_DESCRIPTION_ELEMENT_NAME = "Description";
        private const string DEFAULT_CATEGORY_DESCRIPTION = "No description.";

        /// <summary>
        /// The instances of categories in the application.
        /// </summary>
        private static Dictionary<string, Category> _instances
            = new Dictionary<string, Category>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        private Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public static Category GetCategory(string name)
        {
            if (!_instances.TryGetValue(name, out _))
            {
                CreateCategory(name, DEFAULT_CATEGORY_DESCRIPTION);
            }
            return _instances[name];
        }

        /// <summary>
        /// Creates the category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public static void CreateCategory(string name, string description)
        {
            if (!CategoryIsDefault(name))
            {
                if (_instances.TryGetValue(name, out var category))
                {
                    category.Description = description;
                }
                else
                {
                    new Category(name, description).Store();
                }
            }
        }

        /// <summary>
        /// Removes the category if it is not a default.
        /// </summary>
        /// <param name="name">The name.</param>
        public static void RemoveCategory(string name)
        {
            if (!CategoryIsDefault(name))
            {
                _instances.Remove(name);
            }
        }

        /// <summary>
        /// Loads the default categories.
        /// </summary>
        public static void LoadDefaultCategories()
        {
            _instances.Clear();
            var xml = XDocument.Load(DEFAULT_CATEGORY_RECORD_FILE);
            foreach (var category in xml.Descendants(CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME))
            {
                new Category(category.Attribute(CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME).Value.Trim(),
                    category.Element(CATEGORY_RECORD_XML_CATEGORY_DESCRIPTION_ELEMENT_NAME).Value.Trim()).Store();
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name of the category.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description of the category.
        /// </value>
        public string Description { get; private set; }

        /// <summary>
        /// Stores this instance.
        /// </summary>
        private void Store()
        {
            if (!_instances.ContainsKey(Name))
            {
                _instances.Add(Name, this);
            }
        }

        /// <summary>
        /// Checks if the category is a default category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static bool CategoryIsDefault(string name)
        {
            var nameList = new List<string>();
            var xml = XDocument.Load(DEFAULT_CATEGORY_RECORD_FILE);
            foreach (var category in xml.Descendants(CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME))
            {
                nameList.Add(category.Attribute(CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME)
                    .Value.Trim());
            }

            return nameList.Contains(name);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => Name;

        /// <summary>
        /// Prevents a default instance of the <see cref="Category" /> class from being created.
        /// </summary>
        private Category() { }
    }
}
