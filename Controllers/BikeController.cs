using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication20.Models;
using WebApplication20.VM;

namespace WebApplication20.Controllers
{
    [RoutePrefix("Api/bikes")]
    public class BikeController : ApiController
    {

        rentbikeEntities DB = new rentbikeEntities();
        [Route("FindNearsest")]
        [HttpPost]
        // Based on a longitude,latidude values the nearest bike to the user is returned  
        public object FindNearestBike(Coordinate coordinate)
        {
            List<BikeTbl> bikes = DB.BikeTbls.ToList();

            double min = double.PositiveInfinity;
            BikeTbl result = null;

            foreach(BikeTbl bike in bikes)
            {
                double distance = GetDistance(bike, coordinate);
                if (distance < min)
                {
                    min = distance;
                    result = bike;
                }


            }

            return result;

        }
        // Retrieve a list of all bikes from DB
        [HttpGet]
        [Route("all")]
        public List<BikeTbl> allBikes ()
        {
            return DB.BikeTbls.ToList();

        }
        private static double GetDistance(BikeTbl bike, Coordinate coordinate)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(coordinate.latitude - bike.latitude);
            double b = (double)(coordinate.longitude - bike.longitude);
            return Math.Sqrt(a * a + b * b);
        }

      


    }
}
