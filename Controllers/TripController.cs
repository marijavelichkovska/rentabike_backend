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
        public TripTbl startTrip (int userId,int bikeID)
        {
            TripTbl newTrip = new TripTbl();
            UserTbl user = DB.UserTbls.Find(userId);
            newTrip.startLongitude = user.longitude;
            newTrip.startLatitude = user.latitude;
            newTrip.status ="in-progress";
            newTrip.startTime = DateTime.Now;
            BikeTbl bike = DB.BikeTbls.Find(bikeID);
            if (bike.status.Equals("unlocked"))
            {

                newTrip.BikeTbl = bike;
                newTrip.Bike = bikeID;
                newTrip.UserID = userId;
                DB.TripTbls.Add(newTrip);
                bike.status = "occupied";
                DB.SaveChanges();
            }

            return newTrip;

        }
        [HttpPost]
        [Route("api/trip/end")]
        public TripCost endTrip(int TripID)
        {
            TripTbl trip = DB.TripTbls.Find(TripID);
            trip.status = "finished_not_paid";
            trip.endTime = DateTime.Now;
            BikeTbl bike = DB.BikeTbls.Find(trip.Bike);
            trip.endLongitude = bike.longitude;
            trip.endLatitude = bike.latitude;
            TimeSpan span = (TimeSpan)(trip.endTime - trip.startTime);
            double minutes = span.TotalMinutes;
            int finalCost = (int)(minutes * 0.5);
            trip.cost = finalCost;
            TripCost tripcost = new TripCost();
            tripcost.cost = finalCost;
            tripcost.TripID = TripID;
            DB.SaveChanges();
            return tripcost;
           

        }


        [HttpPost]
        [Route("api/trip/get")]
        public TripTbl getTrip(int TripID)
        {
            TripTbl trip = DB.TripTbls.Find(TripID);
          
            return trip;
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
            trip.status = "finished_paid";
            BikeTbl bike = DB.BikeTbls.Find(trip.Bike);
            bike.status = "locked";
            DB.SaveChanges();
        }

    }
}
