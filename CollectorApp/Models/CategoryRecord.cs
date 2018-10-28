using System.Collections.Generic;

namespace CollectorApp.Models
{
    /// <summary>
    /// Class representing categories of collections.
    /// </summary>
public class CategoryRecord
{
    /// <summary>
    /// The collection record names in this category.
    /// </summary>
    public List<string> Collections;

    /// <summary>
    /// The name of the category.
    /// </summary>
    public string Name;

    /// <summary>
    /// The description of the category.
    /// </summary>
    public string Description;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRecord"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <param name="description">The description.</param>
    public CategoryRecord(string name, string description)
    {
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Adds the collection.
    /// </summary>
    /// <param name="collectionName">Name of the collection.</param>
    public void AddCollection(string collectionName)
    {
        Collections.Add(collectionName);
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
