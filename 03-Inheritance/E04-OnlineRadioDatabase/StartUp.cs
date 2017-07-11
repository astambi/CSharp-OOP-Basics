using System;
using System.Collections.Generic;
using System.Linq;

namespace E04_OnlineRadioDatabase
{
    public class StartUp
    {
        public static void Main()
        {
            var playlist = GetPlaylist();
            PrintPlaylistInfo(playlist);
        }

        private static void PrintPlaylistInfo(List<Song> playlist)
        {
            var playlistLenght = CalculatePlaylistLength(playlist);

            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {playlistLenght[0]}h {playlistLenght[1]}m {playlistLenght[2]}s");
        }

        private static int[] CalculatePlaylistLength(List<Song> playlist)
        {
            long totalLengthSecs = playlist.Sum(s => s.CalculateSongLength());
            var playlistLength = new int[3]; // h : mm: ss
            var index = playlistLength.Length - 1;
            while (totalLengthSecs > 0 && index >= 0)
            {
                playlistLength[index--] = (int)(totalLengthSecs % 60);
                totalLengthSecs /= 60;
            }
            return playlistLength;
        }

        private static List<Song> GetPlaylist()
        {
            var numberOfSongs = int.Parse(Console.ReadLine());
            var playlist = new List<Song>();
            for (int i = 0; i < numberOfSongs; i++)
            {
                try
                {
                    // <artist name>;<song name>;<minutes:seconds>
                    var songInfo = Console.ReadLine()
                                   .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    var artistName = songInfo[0];
                    var songName = songInfo[1];
                    List<int> songDuration;

                    try 
                    {
                        songDuration = songInfo[2]
                                       .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(int.Parse)
                                       .ToList();
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException("Invalid song length."); // NB!
                    }

                    var song = new Song(artistName, songName, songDuration[0], songDuration[1]);
                    playlist.Add(song);
                    Console.WriteLine("Song added.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return playlist;
        }
    }
}
