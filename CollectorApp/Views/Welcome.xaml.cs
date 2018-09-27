using CollectorApp.Models;
using CollectorApp.Utils;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CollectorApp.Views
{
    /// <summary>
    /// The user welcome page.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class Welcome : Page
    {
        private User _activeUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="Welcome"/> class.
        /// </summary>
        public Welcome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked when the Page is loaded and becomes the current source of a parent Frame.
        /// </summary>
        /// <param name="e">Event data that can be examined by overriding code. The event data is representative of the pending navigation that will load the current Page. Usually the most relevant property to examine is Parameter.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _activeUser = (User)e.Parameter;
            if (_activeUser != null)
            {
                UserNameText.Text = _activeUser.Name;
            }
        }

        /// <summary>
        /// Handles the Click event of the Button_Restart control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserSelection));
        }

        /// <summary>
        /// Handles the Click event of the Button_Forget_User control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Forget_User_Click(object sender, RoutedEventArgs e)
        {
            // Remove it from the local accounts list and resave the updated list
            UserHelper.RemoveUser(_activeUser);
            Debug.WriteLine("User " + _activeUser.Name + " deleted.");

            // Navigate back to UserSelection page.
            Frame.Navigate(typeof(UserSelection));
        }
    }
}