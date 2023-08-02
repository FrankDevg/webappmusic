using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WSUserBytesMusic.E_BytesMusic;

namespace WSUserBytesMusic.BL_BytesMusic
{
    [Serializable]
    public class User
    {
        private string strConnectionString;
        public User(string strConnString)
        {
            strConnectionString = strConnString;
        }
        public int Save(EUser user)
        {
            return new DL_BytesMusic.User(strConnectionString).Save(user);
        }
        public DataTable Read()
        {
            return new DL_BytesMusic.User(strConnectionString).Read();
        }

        public int Update(EUser user)
        {
            return new DL_BytesMusic.User(strConnectionString).Update(user);
        }

        public int Delete(int id)
        {
            return new DL_BytesMusic.User(strConnectionString).Delete(id);
        }
        public DataTable AuthenticateUser(string login, string password)
        {
            return new DL_BytesMusic.User(strConnectionString).AuthenticateUser(login, password);
        }
        public int CheckExistUser(string userName)
        {
            return new DL_BytesMusic.User(strConnectionString).CheckExistUser(userName);
        }
        public int CheckExistEmail(string email)
        {
            return new DL_BytesMusic.User(strConnectionString).CheckExistEmail(email);
        }
        public string ValidationsDuplicated(EUser user)
        {
            int returnValue = CheckExistUser(user.UserName);
            if (returnValue != 0)
            {
                return "Username already registered!";
            }
            returnValue = CheckExistEmail(user.Email);
            if (returnValue != 0)
            {
                return "Email already used!.";
            }
            return string.Empty;
        }
    }
}
