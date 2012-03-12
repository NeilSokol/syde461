using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace syde462WPF
{
    // This class is a wrapper for user info
    public class UserInfo
    {
        //Basic user info
        private String username;
        private String password;

        //Eventually add something here that will allow 
        //UserHistoryData object to be associated with UserInfo

        //default constructor
        public UserInfo()
        {
            username = "";
            password = "";
        }

        //constructor for when username and password are already known
        public UserInfo(String name, String pass)
        {
            username = name;
            password = pass;
        }

        //Method for setting userInfo for the first time
        public UserInfo setUserInfo(String name, String pass)
        {
            this.username = name;
            this.password = pass;

            return this;
        }

        //Method for checking if passed info matches existing UserInfo instance
        //For when not a UserInfo instance
        //We probably will be able to remove this method later
        public bool checkUserInfo(String name, String pass)
        {
            bool usernamematch = false; 
            bool passwordmatch = false;

            if (this.username == name)
                usernamematch = true;
            if (this.password == pass)
                passwordmatch = true;

            return (usernamematch & passwordmatch);
        }

        //Method for checking if two UserInfo objects are the same
        public bool checkUserInfo(UserInfo compare)
        {
            bool usernamematch = false;
            bool passwordmatch = false;

            if (this.username == compare.username)
                usernamematch = true;
            if (this.password == compare.password)
                passwordmatch = true;

            return (usernamematch & passwordmatch);
        }

        //Allows for a user to change their password
        //User must input their old password
        private void changePassword(String name, String pass, String newpass)
        {
            if (this.checkUserInfo(name, pass) == true)
                this.password = newpass;

        }

        //Check the username of a UserInfo instance
        public String getUsername()
        {
            return this.username;
        }
        
        //Check the password of a UserInfo instance
        //This method should eventually be made private or removed entirely
        public String getPassword()
        {
            return this.password;
        }
    }
}
