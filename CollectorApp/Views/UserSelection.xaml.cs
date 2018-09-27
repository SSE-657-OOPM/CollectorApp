using CollectorApp.Models;
using CollectorApp.Utils;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollectorApp.Views
{
    /// <summary>
    /// Page for selecting users in the application.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class UserSelection : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserSelection"/> class.
        /// </summary>
        public UserSelection()
        {
            InitializeComponent();
            Loaded += UserSelection_Loaded;
        }

        /// <summary>
        /// Handles the Loaded event of the UserSelection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void UserSelection_Loaded(object sender, RoutedEventArgs e)
        {
            if (UserHelper.UserList.Count == 0)
            {
                //If there are no users navigate to the LoginPage
                Frame.Navigate(typeof(Login));
            }

            UserListView.ItemsSource = UserHelper.UserList;
            UserListView.SelectionChanged += UserSelectionChanged;
        }

        /// <summary>
        /// Function called when an user is selected in the list of users
        /// Navigates to the Login page and passes the chosen user
        /// </summary>
        private void UserSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (((ListView)sender).SelectedValue != null)
            {
                User user = (User)((ListView)sender).SelectedValue;
                if (user != null)
                {
                    Debug.WriteLine("User " + user.Name + " selected!");
                }
                Frame.Navigate(typeof(Login), user);
            }
        }

        /// <summary>
        /// Function called when the "+" button is clicked to add a new user.
        /// Navigates to the Login page with nothing filled out
        /// </summary>
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }
    }
}
