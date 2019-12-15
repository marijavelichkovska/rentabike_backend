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

        TripDatabase DB = new TripDatabase();
        [Route("FindNearsest")]
        [HttpPost]
        public object FindNearest(Coordinate coordinate)
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
        private static double GetDistance(BikeTbl point1, Coordinate point2)
        {
            //pythagorean theorem c^2 = a^2 + b^2
            //thus c = square root(a^2 + b^2)
            double a = (double)(point2.latitude - point1.latitude);
            double b = (double)(point2.longitude - point1.longitude);

            return Math.Sqrt(a * a + b * b);
        }

        double distance(double x1, double y1, double x2, double y2)
        {

            return Math.Sqrt(Math.Pow(((double)x1 - (double)x2), 2) - Math.Pow(((double)y1 - (double)y2), 2));

        }


    }
}
