using CollectorApp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CollectorApp.Views
{
    /// <summary>
    /// Page displaying the all collections contained within the app.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    public sealed partial class CollectionsPage : Page
    {
        ObservableCollection<CollectionRecord> _collections;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllCollectionsView"/> class.
        /// </summary>
        public CollectionsPage()
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
            _collections = (ObservableCollection<CollectionRecord>)e.Parameter;
        }

        /// <summary>
        /// Adds the collection.
        /// </summary>
        public void AddCollection()
        {
            System.Diagnostics.Debug.WriteLine("Collection Added");
        }

        /// <summary>
        /// Goes to collection.
        /// </summary>
        public void GoToCollection()
        {
            Frame.Navigate(typeof(ItemsPage), _collections.FirstOrDefault(c => c.Name == Collections.SelectedItem.ToString()));
        }
    }
}
