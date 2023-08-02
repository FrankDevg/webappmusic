﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSUserBytesMusic.E_BytesMusic
{
    public class EUser
    {
        public EUser()
        {
        }
        public EUser(int id, string username, string password, string email, string birthday, int userType, string photo)
        {
            ID = id;
            UserName = username;
            Password = password;
            Email = email;
            Birthday = birthday;
            UserType = userType;
            Photo = photo;
        }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public int UserType { get; set; }
        public string Photo { get; set; }
    }
}
