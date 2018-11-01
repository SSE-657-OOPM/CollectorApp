using System.Collections.Generic;
using System.Xml.Linq;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing categories of collections.
    /// </summary>
    public class CategoryRecord
    {
        private const string DEFAULT_CATEGORY_RECORD_FILE = "./Resources/CategoryRecords.xml";
        private const string CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME = "CategoryRecord";
        private const string CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME = "Name";
        private const string CATEGORY_RECORD_XML_CATEGORY_DESCRIPTION_ELEMENT_NAME = "Description";
        private const string DEFAULT_DESCRIPTION = "No description.";

        /// <summary>
        /// The instances of category records in the application.
        /// </summary>
        private static Dictionary<string, CategoryRecord> _instances
            = new Dictionary<string, CategoryRecord>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryRecord"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        private CategoryRecord(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Creates the category record.
        /// </summary>
        /// <param name="categoryName">Name of the category.</param>
        /// <returns></returns>
        public static CategoryRecord GetCategoryRecord(string name)
        {
            if (!_instances.TryGetValue(name, out _))
            {
                CreateCategoryRecord(name, DEFAULT_DESCRIPTION);
            }
            return _instances[name];
        }

        /// <summary>
        /// Creates the category record.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        public static void CreateCategoryRecord(string name, string description)
        {
            if (!CategoryRecordIsDefault(name))
            {
                if (_instances.TryGetValue(name, out var category))
                {
                    category.Description = description;
                }
                else
                {
                    new CategoryRecord(name, description).Store();
                }
            }
        }

        /// <summary>
        /// Removes the category record.
        /// </summary>
        /// <param name="name">The name.</param>
        public static void RemoveCategoryRecord(string name)
        {
            if (!CategoryRecordIsDefault(name))
            {
                _instances.Remove(name);
            }
        }

        /// <summary>
        /// Loads the default category records.
        /// </summary>
        public static void LoadDefaultCategoryRecords()
        {
            _instances.Clear();
            var xml = XDocument.Load(DEFAULT_CATEGORY_RECORD_FILE);
            foreach (var category in xml.Descendants(CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME))
            {
                new CategoryRecord(category.Attribute(CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME).Value.Trim(),
                    category.Element(CATEGORY_RECORD_XML_CATEGORY_DESCRIPTION_ELEMENT_NAME).Value.Trim()).Store();
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name of the category record.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description of the category record.
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
        /// Checks if the category record is a default category.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static bool CategoryRecordIsDefault(string name)
        {
            var nameList = new List<string>();
            var xml = XDocument.Load(DEFAULT_CATEGORY_RECORD_FILE);
            foreach (var category in xml.Descendants(CATEGORY_RECORD_XML_CATEGORY_ELEMENT_NAME))
            {
                nameList.Add(category.Attribute(CATEGORY_RECORD_XML_CATEGORY_NAME_ATTRIBUTE_NAME).Value.Trim());
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
        /// Prevents a default instance of the <see cref="CategoryRecord" /> class from being created.
        /// </summary>
        private CategoryRecord() { }
    }
}
