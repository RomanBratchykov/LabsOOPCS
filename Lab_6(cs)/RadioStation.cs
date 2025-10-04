using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    internal class RadioStation
    {
        private List<Song> playlist;
        public RadioStation()
        {
            playlist = new List<Song>();
        }
        public void AddSong(Song song)
        {
            playlist.Add(song);
        }
        public TimeSpan FullLength
        {
            get { return getFullLength(); }
        }
        public List<Song> Playlist
        {
            get { return playlist; }
        }
        private TimeSpan getFullLength()
        {
            TimeSpan fullLength = new TimeSpan(0, 0, 0);
            foreach (var song in playlist)
            {
                fullLength = fullLength.Add(song.Length);
            }
            return fullLength;
        }
    }

}
