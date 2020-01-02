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
    public class TripController : ApiController
    {
        rentbikeEntities DB = new rentbikeEntities();

        [HttpPost]
        [Route("api/trip/start")]

        //  The trip is started with unique userId and bikeId as parameters 

        public void startTrip (int userId,int bikeID)
        {
            TripTbl newTrip = new TripTbl();
            //Retrieve from database user and bike with unique values of ids
            UserTbl user = DB.UserTbls.Find(userId);
            BikeTbl bike = DB.BikeTbls.Find(bikeID);

            // Set the start coordinates of the trip to be the same as the user's 
            newTrip.startLongitude = user.longitude;
            newTrip.startLatitude = user.latitude;
            newTrip.startTime = DateTime.Now;
            // Change the status of the trip 
            newTrip.status ="in-progress";
           
            // Only unlocked bikes are available for a trip
            if (bike.status.Equals("unlocked"))
            {
                newTrip.BikeTbl = bike;
                newTrip.Bike = bikeID;
                newTrip.UserID = userId;
                DB.TripTbls.Add(newTrip);
                // Change the status of the bike from unlocked to occupied when the trip is started 
                bike.status = "occupied";

                DB.SaveChanges();
            }



        }
        [HttpPost]
        [Route("api/trip/end")]
        public TripCost endTrip(int TripID)
        {
            TripTbl trip = DB.TripTbls.Find(TripID);
            // Change the status of the trip to be in a mid-state before the payment
            trip.status = "finished_not_paid";
            trip.endTime = DateTime.Now;
            BikeTbl bike = DB.BikeTbls.Find(trip.Bike);

            // Set the end coordinates to be the same as bikes coordinates at the end of trip
            trip.endLongitude = bike.longitude;
            trip.endLatitude = bike.latitude;

            // Calculates the time of the trip in minutes
            TimeSpan span = (TimeSpan)(trip.endTime - trip.startTime);
            double minutes = span.TotalMinutes;


            int finalCost = (int)(minutes * 0.5);
            trip.cost = finalCost;
            TripCost tripcost = new TripCost();
            tripcost.cost = finalCost;
            tripcost.TripID = TripID;
            DB.SaveChanges();
            // Returns an object of a pair of tripId and cost of trip
            return tripcost;
           

        }
        [HttpPost]
        [Route("api/trip/makePayment")]
        public void makePayment (int tripId, int cost,int userId)
        {
            UserTbl user = DB.UserTbls.Find(userId);
            string card = user.cardNum;
            PaymentsTbl payment = new PaymentsTbl();
            payment.cardNum = card;
            payment.cost = cost;
            payment.tripID = tripId;
            DB.PaymentsTbls.Add(payment);
            TripTbl trip = DB.TripTbls.Find(tripId);
            // Changes the status from "finished-not-paid" to "finished-paid"
            trip.status = "finished_paid";
            BikeTbl bike = DB.BikeTbls.Find(trip.Bike);
            // Change the status back to lock when payment is done
            bike.status = "locked";
            DB.SaveChanges();
        }

    }
}
