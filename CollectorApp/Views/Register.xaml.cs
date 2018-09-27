using CollectorApp.Models;
using CollectorApp.Utils;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CollectorApp.Views
{
    /// <summary>
    /// Page for registering users in the application.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class Register : Page
    {
        private User _user;

        /// <summary>
        /// Initializes a new instance of the <see cref="Register"/> class.
        /// </summary>
        public Register()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the RegisterButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Text = string.Empty;

            //In the real world you would normally validate the entered credentials and information before 
            //allowing a user to register a new account. 
            //For this sample though we will skip that step and just register an account if username is not null.
            if (!string.IsNullOrEmpty(UsernameTextBox.Text))
            {
                //Register a new account
                _user = UserHelper.AddUser(UsernameTextBox.Text);
                //Navigate to the Welcome Screen. 
                Frame.Navigate(typeof(Welcome), _user);
            }
            else
            {
                ErrorMessage.Text = "Please enter a username";
            }
        }
    }
}
