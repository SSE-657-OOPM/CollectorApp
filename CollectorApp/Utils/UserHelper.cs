using CollectorApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;

namespace CollectorApp.Utils
{
    /// <summary>
    /// Class used to add and check for users in application.
    /// </summary>
    class UserHelper
    {
        // In the real world this would not be needed as there would be a server implemented that would host a user account database.
        // For this tutorial we will just be storing users locally.
        private const string USER_ACCOUNT_LIST_FILE_NAME = "userlist.txt";
        private static readonly string _userListPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, USER_ACCOUNT_LIST_FILE_NAME);
        public static List<User> UserList = new List<User>();

        /// <summary>
        /// Create and save a useraccount list file. (Updating the old one)
        /// </summary>
        private static async void SaveUserListAsync()
        {
            var usersXml = SerializeUserListToXml();
            if (File.Exists(_userListPath))
            {
                var usersFile = await StorageFile.GetFileFromPathAsync(_userListPath);
                await FileIO.WriteTextAsync(usersFile, usersXml);
            }
            else
            {
                var usersFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(USER_ACCOUNT_LIST_FILE_NAME);
                await FileIO.WriteTextAsync(usersFile, usersXml);
            }
        }

        /// <summary>
        /// Gets the useraccount list file and deserializes it from XML to a list of useraccount objects.
        /// </summary>
        /// <returns>List of useraccount objects</returns>
        public static async Task<List<User>> LoadUserListAsync()
        {
            if (File.Exists(_userListPath))
            {
                var usersFile = await StorageFile.GetFileFromPathAsync(_userListPath);
                var usersXml = await FileIO.ReadTextAsync(usersFile);
                DeserializeXmlToUserList(usersXml);
            }

            return UserList;
        }

        /// <summary>
        /// Uses the local list of accounts and returns an XML formatted string representing the list
        /// </summary>
        /// <returns>XML formatted list of accounts</returns>
        public static string SerializeUserListToXml()
        {
            var xmlizer = new XmlSerializer(typeof(List<User>));
            var writer = new StringWriter();
            xmlizer.Serialize(writer, UserList);

            return writer.ToString();
        }

        /// <summary>
        /// Takes an XML formatted string representing a list of accounts and returns a list object of accounts
        /// </summary>
        /// <param name="listAsXml">XML formatted list of accounts</param>
        /// <returns>List object of accounts</returns>
        public static List<User> DeserializeXmlToUserList(string listAsXml)
        {
            var xmlizer = new XmlSerializer(typeof(List<User>));
            var textreader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(listAsXml)));

            return UserList = xmlizer.Deserialize(textreader) as List<User>;
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static User AddUser(string username)
        {
            // Create a new account with the username
            var user = new User() { Name = username };
            // Add it to the local list of users
            UserList.Add(user);
            // SaveUserList and return the user
            SaveUserListAsync();
            return user;
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public static void RemoveUser(User user)
        {
            // Remove the user from the users list
            UserList.Remove(user);
            // Re save the updated list
            SaveUserListAsync();
        }

        /// <summary>
        /// Validates the user credentials.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public static bool ValidateUserCredentials(string username)
        {
            // In the real world, this method would call the server to authenticate that the account exists and is valid.
            // For this tutorial however we will just have a existing sample user that is just "sampleUsername"
            // If the username is null or does not match "sampleUsername" it will fail validation. In which case the user should register a new passport user
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            if (!string.Equals(username, "sampleUsername"))
            {
                return false;
            }

            return true;
        }
    }
}
