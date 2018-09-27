using CollectorApp.Models;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CollectorApp.Views
{
    /// <summary>
    /// Page displaying the items for a given collection.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class ItemsPage : Page
    {
        CollectionRecord _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsPage"/> class.
        /// </summary>
        public ItemsPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the Page is loaded and becomes the current source of a parent Frame.
        /// </summary>
        /// <param name="e">
        /// Event data that can be examined by overriding code. The event data
        /// is representative of the pending navigation that will load the current Page.
        /// Usually the most relevant property to examine is Parameter.
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _collection = (CollectionRecord)e.Parameter;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        private void AddItem()
        {
            System.Diagnostics.Debug.WriteLine("Item Added");
        }
    }
}
