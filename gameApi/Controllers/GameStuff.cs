using gameApi.Models1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
/// useless class, had to migrate all this to GameStuff.cs class. should be deleted, not sure aboyt it yet tho.
/// 
/// </summary>
namespace gameApi.Controllers
{
    [Route("GameStuff")]
    [ApiController]
    public class GameStuff : ControllerBase  // /api/GameStuff 
    {
        [HttpGet]
        public IActionResult start()
        {
            return Ok("Funciones implementadas: getall , getbyname -{nombre} , getbystudio-{studio} , getbygenre-{genre} "); //why im coding this in english? this is for weones
        }

        [HttpGet("getallgames")]
        public IEnumerable<Game> getAllGames() // returns all games on the database. 

        {
            using (var context = new gameApiContext())
            {
                return context.Games.ToList();
            }
        }

        [HttpGet("getgamebyname-{name}")]
        public IEnumerable<Game> getgameByName(string name) //returns game info by looking for it by his name. 
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.GameName == name).ToList();
            }
        }

        [HttpGet("getbystudio-{studio}")]
        public IEnumerable<Game> getByStudio(string studio) //returns all games, filtering by a particular game studio
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.Studio == studio).ToList();
            }
        }

        [HttpGet("getbygenre-{genre}")]
        public IEnumerable<Game> getByGenre(string genre) //returns all games on a specific genre
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.Genre == genre).ToList();
            }
        }

        [HttpGet("getbyplatform-{platform}")]
        public IEnumerable<Game> getByplatform(string platform) //returns all games on a specific genre
        {
            using (var context = new gameApiContext())
            {
                return context.Games.Where(Game => Game.GamePlatform == platform).ToList();
            }
        }

        [HttpPost("newgame")] // lern to test this one propertly

        public IEnumerable<Game> newgame([FromBody] Game auxGame) //receives a a formated json object, then adds it to the database
        {
            using (var context = new gameApiContext())
            {
                context.Add(auxGame);
                context.SaveChanges();
                return context.Games.Where(Game => Game.GameName == auxGame.GameName).ToList(); //returns the new game in json format (in theory)
            }

        }
        
        [HttpPut("updategame")]  //requires json formated data and a game id to update
        public IEnumerable<Game> updateGame (int id ,[FromBody] Game auxGame)
        {
            using (gameApiContext context = new gameApiContext())
            {
                var game = context.Games.FirstOrDefault(e => e.GameId == id);
                game.GameName = auxGame.GameName;
                game.GameId = auxGame.GameId;
                game.Genre = auxGame.Genre;
                game.GamePlatform = auxGame.GamePlatform;
                game.Studio = auxGame.Studio;
                context.SaveChanges();
                return context.Games.Where(Game => Game.GameName == auxGame.GameName).ToList();
            }
                       
        }

        [HttpDelete("deletegame-{id}")]
        public IEnumerable<Game> deletegame (int id)
        {
            using(gameApiContext context = new gameApiContext())
            {
                context.Games.Remove(context.Games.FirstOrDefault(e => e.GameId == id));
                context.SaveChanges();
                return context.Games.ToList();
            }
        }

        [HttpGet("getallstudio")]
        public IEnumerable<Studio> getAlls() // returns all games on the database. 

        {
            using (var context = new gameApiContext())
            {
                return context.Studios.ToList();
            }
        }

        [HttpGet("getstudiobyname-{name}")]
        public IEnumerable<Studio> getStudioByName(string name) //returns game info by looking for it by his name. 
        {
            using (var context = new gameApiContext())
            {
                return context.Studios.Where(Studio => Studio.StudioName == name).ToList();
            }

        }

        [HttpPost("newstudio")] // lern to test this one propertly

        public IEnumerable<Studio> newstudio([FromBody] Studio auxStudio) //receives a a formated json object, then adds it to the database
        {
            using (var context = new gameApiContext())
            {
                context.Add(auxStudio);
                context.SaveChanges();
                return context.Studios.Where(Studio => Studio.StudioName == auxStudio.StudioName).ToList(); //returns the studio in json format (in theory)
            }

        }

        [HttpPut("updatestudio")]  //requires json formated data and a studio id to update
        public IEnumerable<Studio> updateStudio(string id, [FromBody] Studio auxStudio)
        {
            using (gameApiContext context = new gameApiContext())
            {
                var Studio = context.Studios.FirstOrDefault(e => e.StudioId == id);
                Studio.StudioName = auxStudio.StudioName;
                Studio.StudioId = auxStudio.StudioId;
                context.SaveChanges();
                return context.Studios.Where(Studio => Studio.StudioName == auxStudio.StudioName).ToList();
            }

        }

        [HttpDelete("deletestudio-{id}")]
        public IEnumerable<Studio> deletestudio(string id) //somehow studio id ended up being a string instead of an int, im rolling with it
        {
            using (gameApiContext context = new gameApiContext())
            {
                context.Studios.Remove(context.Studios.FirstOrDefault(e => e.StudioId == id));
                context.SaveChanges();
                return context.Studios.ToList();
            }
        }

        [HttpGet("getvalue")]
        public IEnumerable<GameEarning> getvalues() // returns all earnings made on the industrie (the ones on the database. )

        {
            using (var context = new gameApiContext())
            {
                return context.GameEarnings.ToList();
            }
        }
    }
}























//pre made object in json format for testing the post thingie 
//{
//   "gameName": "Battlefield 1",
//   "gameId": 40,
//   "genre": "shooter",
//   "gamePlatform": "Pc",
//   "studio": "Electronic arts"
//},

// delete from dbo.game where name_name = "Battlefield 1";       /// use if the test actually works ///


