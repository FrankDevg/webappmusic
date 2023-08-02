using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp2BytesMusic.E_BytesMusic;

namespace WebApp2BytesMusic.User
{
    public class UserRules
    {
        public string UserFieldsRequiredValidations(EUser user)
        {
            if (user.Username == string.Empty)
            {
                return "Username is required!";
            }
            if (user.Email == string.Empty)
            {
                return "Email is required!";
            }
            if (user.Password == string.Empty)
            {
                return "Password is required!";
            }
            if (!Util.Validator.IsValidEmail(user.Email))
            {
                return "Email is not valid!";
            }
            return string.Empty;
        }
    }
}