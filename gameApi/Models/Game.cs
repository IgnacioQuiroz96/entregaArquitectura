using System;
using System.Collections.Generic;

#nullable disable

namespace gameApi.Models1
{
    public partial class Game
    {
        public string GameName { get; set; }
        public int GameId { get; set; }
        public string Genre { get; set; }
        public string GamePlatform { get; set; }
        public string Studio { get; set; }

        public virtual GameEarning GameEarning { get; set; }
    }
}
