using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gameApi.Models;

namespace gameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioStuff : ControllerBase  // /api/StudioStuff
    {


        [HttpGet]
        public IActionResult start()
        {
            return Ok("Funciones implementadas: getall , getbyname -{nombre}  , getbygenre-{genre} "); //why im coding this in english? this is for weones
        }






        [HttpGet("getall")]
        public IEnumerable<Studio> getAll() // returns all games on the database. 

        {
            using (var context = new gameApiContext())
            {
                return context.Studios.ToList();
            }
        }

        [HttpGet("getbyname-{name}")]
        public IEnumerable<Studio> getByName(string name) //returns game info by looking for it by his name. 
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

        [HttpDelete("delete-{name}")]
        public IEnumerable<Studio> delete(string name)
        {
            using (gameApiContext context = new gameApiContext())
            {
                context.Studios.Remove(context.Studios.FirstOrDefault(e => e.StudioName == name));
                context.SaveChanges();
                return context.Studios.ToList();
            }
        }
    }
}