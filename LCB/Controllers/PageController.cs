using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Twinvision.Destion.Website.Controllers
{
    public class PagesController : Controller
    {

        private readonly IConfiguration _config;
        public PagesController()
        {

        }

        [Route("/SearchValue")]
        public IActionResult GetApiData(string ApiString)
        {

            ConnectionMultiplexer rediscon = ConnectionMultiplexer.Connect("redis-17579.c56.east-us.azure.cloud.redislabs.com:17579,password=26xvQbmUjn9n9vPxgeNVKkvMb8eaJoVq");
            IDatabase db = rediscon.GetDatabase();

            //Get Api data lcb
            db.StringSet("LCBData", "");

            return View();
        }


        [Route("/SearchValue")]
        public IActionResult Search(string SearchValue)
        {
            
            ConnectionMultiplexer rediscon = ConnectionMultiplexer.Connect("redis-17579.c56.east-us.azure.cloud.redislabs.com:17579,password=26xvQbmUjn9n9vPxgeNVKkvMb8eaJoVq");
            IDatabase db = rediscon.GetDatabase();


            string val = db.StringGet(SearchValue);
            return View(val);
        }
    }
}
