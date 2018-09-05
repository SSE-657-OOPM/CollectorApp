using CollectorApp.Models;
using CollectorApp.Views;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace CollectorApp
{
    /// <summary>
    /// Page defining the split view for the navigation menu of the app.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class AppShell : Page
    {
        User _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
            AddDummyCollections();
            AppFrame?.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Gets the application frame.
        /// </summary>
        /// <value>
        /// The application frame.
        /// </value>
        public Frame AppFrame => frame;

        /// <summary>
        /// Goes to collections page.
        /// </summary>
        public void GoToCollectionsPage()
        {
            AppFrame?.Navigate(typeof(CollectionsPage), _user.Collections);
            HamburgerMenu.SelectedItem = CollectionButton;
        }

        /// <summary>
        /// Goes to settings page.
        /// </summary>
        public void GoToSettingsPage()
        {
            AppFrame?.Navigate(typeof(SettingsPage));
            HamburgerMenu.SelectedItem = SettingsButton;
        }

        private void AddDummyCollections()
        {
            _user = new User();
            var itemsA = new ObservableCollection<ItemRecord>()
            {
                GetItemRecord("Item A"),
                GetItemRecord("Item B"),
                GetItemRecord("Item C")
            };
            var itemsB = new ObservableCollection<ItemRecord>()
            {
                GetItemRecord("Item A"),
                GetItemRecord("Item B")
            };
            var itemsC = new ObservableCollection<ItemRecord>()
            {
                GetItemRecord("Item A"),
                GetItemRecord("Item B"),
                GetItemRecord("Item C"),
                GetItemRecord("Item D"),
                GetItemRecord("Item E"),
                GetItemRecord("Item F")
            };
            _user.Collections = new ObservableCollection<CollectionRecord>()
            {
                GetCollectionRecord("Collection A", itemsA),
                GetCollectionRecord("Collection B", itemsB),
                GetCollectionRecord("Collection C", itemsC)
            };
        }

        private ItemRecord GetItemRecord(string name)
        {
            return new ItemRecord { Name = name };
        }

        private CollectionRecord GetCollectionRecord(string name, ObservableCollection<ItemRecord> itemRecords)
        {
            return new CollectionRecord { Name = name, Items = itemRecords };
        }
    }
}
