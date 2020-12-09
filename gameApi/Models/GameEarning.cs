using System;
using System.Collections.Generic;

#nullable disable

namespace gameApi.Models1
{
    public partial class GameEarning
    {
        public int GameId { get; set; }
        public int TotalSold { get; set; }
        public int GamePrice { get; set; }

        public virtual Game Game { get; set; }
    }
}
