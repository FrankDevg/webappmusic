using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp2BytesMusic.E_BytesMusic
{
    public class EArtist
    {
        private int artistID;
        private string firstName;
        private string lastName;
        private string imagePath;

        public int Id_Artist { get { return artistID; } set { artistID = value; } }
        public string Artist_Name { get { return firstName; } set { firstName = value; } }
        public string Artist_LastName { get { return lastName; } set { lastName = value; } }
        public string Artist_Image { get { return imagePath; } set { imagePath = value; } }
    }
}