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

        void UserInfo()
        {
            username = "";
            password = "";
        }

        void UserInfo(String name, String pass)
        {
            username = name;
            password = pass;
        }

        String checkUserInfo(String name, String pass)
        {

        }

        String changePassword(String name, String pass)
        {

        }

        String getUserInfo(String name, String pass)
        {

        }
    }
}
