using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SYDE461_UI
{
    public class UserInfo
    {
        private String username;
        private String password;

        public UserInfo()
        {
            username = "";
            password = "";
        }

        public UserInfo(String name, String pass)
        {
            username = name;
            password = pass;
        }

        public UserInfo setUserInfo(String name, String pass)
        {
            this.username = name;
            this.password = pass;

            return this;
        }

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


        private void changePassword(String name, String pass, String newpass)
        {
            if (this.checkUserInfo(name, pass) == true)
                this.password = newpass;

        }

        public String getUsername()
        {
            return this.username;
        }
        public String getPassword()
        {
            return this.password;
        }
    }
}
