using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2BytesMusic.E_BytesMusic
{
    public class EUser

    {
        public EUser()
        {
        }
        public EUser(int id, string username, string password, string email, string birthday, int userType, string photo)
        {
            Id_User = id;
            Username = username;
            Password = password;
            Email = email;
            Birthday = birthday;
            User_Type = userType;
            User_Photo = photo;
        }
        public int Id_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public int User_Type { get; set; }

        public string User_Photo { get; set; }
    }
}