using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSArtistBytesMusic.E_BytesMusic
{
    public class EArtist
    {
        private int artistID;
        private string firstName;
        private string lastName;
        private string imagePath;

        public int ID { get { return artistID; } set { artistID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string ImagePath { get { return imagePath; } set { imagePath = value; } }
    }
}