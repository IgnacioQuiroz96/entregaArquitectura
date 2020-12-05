using System;
using System.Collections.Generic;

#nullable disable

namespace gameApi.Models
{
    public partial class Game
    {
        public string GameName { get; set; }
        public int GameId { get; set; }
        public string Genre { get; set; }
        public string GamePlatform { get; set; }
        public string Studio { get; set; }

        public Game(string gameName, int gameId, string genre, string gamePlatform, string studio) //constructor, made for the post method. 
        {
            GameName = gameName;
            GameId = gameId;
            Genre = genre;
            GamePlatform = gamePlatform;
            Studio = studio;
        }
    }
}
