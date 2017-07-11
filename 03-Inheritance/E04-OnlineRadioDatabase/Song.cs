using System;

namespace E04_OnlineRadioDatabase
{
    public class Song
    {
        private string artistName;
        private string songName;
        private int songMinutes;
        private int songSeconds;

        public Song(string artistName, string songName, int songMinutes, int songSeconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.SongMinutes = songMinutes;
            this.SongSeconds = songSeconds;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new ArgumentException("Artist name should be between 3 and 20 symbols.");
                }
                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new ArgumentException("Song name should be between 3 and 30 symbols.");
                }
                this.songName = value;
            }
        }

        public int SongMinutes
        {
            get { return this.songMinutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new ArgumentException("Song minutes should be between 0 and 14.");
                }
                this.songMinutes = value;
            }
        }

        public int SongSeconds
        {
            get { return this.songSeconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Song seconds should be between 0 and 59.");
                }
                this.songSeconds = value;
            }
        }

        public int CalculateSongLength()
        {
            return this.SongMinutes * 60 + this.SongSeconds;
        }        
    }
}
