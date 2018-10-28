using CollectorApp.Views;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            InitializeComponent();
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
        private void GoToCollectionsPage()
        {
            if (AppFrame?.Content.GetType() != typeof(CollectionsPage))
            {
                AppFrame?.Navigate(typeof(CollectionsPage));
                HamburgerMenu.SelectedItem = CollectionButton;
            }
        }

        /// <summary>
        /// Goes to settings page.
        /// </summary>
        private void GoToSettingsPage()
        {
            if (AppFrame?.Content.GetType() != typeof(SettingsPage))
            {
                AppFrame?.Navigate(typeof(SettingsPage));
                HamburgerMenu.SelectedItem = SettingsButton;
            }
        }
    }
}
