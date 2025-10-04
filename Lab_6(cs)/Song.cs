using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class Song
    {
        private string author;
        private string name;
        private TimeSpan length;
        public Song(string author, string name, TimeSpan length)
        {
            Author = author;
            Name = name;
            Length = length;
        }
        public string Author
        {
            get { return author; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                author = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidSongNameException();
                }
                name = value;
            }
        }
        public TimeSpan Length
        {
            get { return length; }
            set
            {
                if (value.TotalMinutes < 0 || value.TotalMinutes > 14)
                {
                    throw new InvalidSongMinutesException();
                }
                if (value.Seconds < 0 || value.Seconds > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                length = value;
            }
        }
    }
}
