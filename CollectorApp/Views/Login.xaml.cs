using CollectorApp.Models;
using CollectorApp.Utils;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace CollectorApp.Views
{
    /// <summary>
    /// Page for logging in as different users.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class Login : Page
    {
        private User _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="Login"/> class.
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Function called when this frame is navigated to.
        /// Checks to see if Microsoft Passport is available and if an account was passed in.
        /// If an account was passed in set the "_isExistingAccount" flag to true and set the _account
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                // Set the account to the existing account being passed in
                _user = (User)e.Parameter;
                UsernameTextBox.Text = _user.Name;
                SignIn();
            }
        }

        /// <summary>
        /// Handles the Click event of the SignInButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            SignIn();
        }

        /// <summary>
        /// Handles the OnPointerPressed event of the RegisterButtonTextBlock control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PointerRoutedEventArgs"/> instance containing the event data.</param>
        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = string.Empty;
            Frame.Navigate(typeof(Register));
        }

        /// <summary>
        /// Signs in.
        /// </summary>
        private void SignIn()
        {
            if (UserHelper.UserList.Contains(_user))
            {
                Frame.Navigate(typeof(Welcome), _user);
            }
            else if (UserHelper.ValidateUserCredentials(UsernameTextBox.Text))
            {
                //Create and add a new local account
                _user = UserHelper.AddUser(UsernameTextBox.Text);
                Debug.WriteLine("Successfully signed in with traditional credentials and created local account instance!");
                Frame.Navigate(typeof(Welcome), _user);
            }
            else
            {
                ErrorMessage.Text = "Invalid Credentials";
            }
        }
    }
}