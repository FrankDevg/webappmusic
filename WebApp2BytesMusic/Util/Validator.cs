using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using WebApp2BytesMusic.E_BytesMusic;

namespace WebApp2BytesMusic.Util
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            if (email == string.Empty || email.Replace(" ", "") == string.Empty)
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None);

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (Exception)
            {
                return false;
            }
            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        public static string ValidationsDuplicated(int username, int email)
        {
            int returnValue = username;
            if (returnValue != 0)
            {
                return "Username already registered!";
            }
            returnValue = email;
            if (returnValue != 0)
            {
                return "Email already used!.";
            }
            return string.Empty;
        }
        public static string FieldsRequiredValidations(EPlaylist playlist)
        {
            if (playlist.Title == string.Empty)
            {
                return "Title is required!";
            }
            return string.Empty;
        }
        public static string CatalogValidations(ECatalog catalog)
        {
            if (catalog.Cod_Catalog == string.Empty || catalog.Cod_Catalog_Parent == string.Empty)
            {
                return "Code or Code Parent catalog is required!";
            }
            if (catalog.Value == string.Empty)
            {
                return "A value for the Catalog is required!";
            }
            return string.Empty;
        }
        public static string ArtistValidations(EArtist artist)
        {
            if (artist.Artist_Name == string.Empty || artist.Artist_LastName == string.Empty)
            {
                return "First and LastName are required!";
            }
            try
            {
                //int returnValue = CheckExistArtist(artist);
                string url = ConfigurationManager.AppSettings["apiGateway"] + "/checkExistArtist";
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                request.Accept = "application/json";
                request.ContentType = "application/json";
                request.Method = "POST";
                string requestJson = JsonConvert.SerializeObject(artist);
                byte[] bytes = Encoding.UTF8.GetBytes(requestJson);
                Stream newStream = request.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();
                newStream.Dispose();
                var response = request.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream).ReadToEnd();
                int returnValue = Int32.Parse(sr);

                if (returnValue != 0)
                {
                    return "Album already exist!"; ;
                }

                return string.Empty;
            }
            catch (Exception exp)
            {
                return "Error en el servidor intentelo en unos momentos";
                
            }
        }

    }
}