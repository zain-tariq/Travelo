using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext obj = new DataClasses1DataContext();

        public ActionResult index()
        {
            return View();
        }

        public ActionResult getFlightDetails()
        {
            string destination = Request["Destination"];
            string date = Request["Date"];
            string departure = Request["from"];
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var temp = dc.flightDetails.Where(c => c.Destination == destination)
                                       .Where(c => c.Departure == departure)
                                       .Where(c => c.Date == date);
            return View(temp);
        }

        public ActionResult admin()
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var temp = dc.flightDetails.ToList();
            return View(temp);
        }

        public ActionResult deleteFlight()
        {
            string id = Request["id"];
            int temp = Int32.Parse(id);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var row = dc.flightDetails.Where(c => c.Id == temp).First();
            dc.flightDetails.DeleteOnSubmit(row);
            dc.SubmitChanges();

            return RedirectToAction("admin");
        }

        public ActionResult addFlight()
        {
            return View();
        }

        public ActionResult editFlight()
        {
            string id = Request["id"];
            int temp = Int32.Parse(id);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var row = dc.flightDetails.Where(c => c.Id == temp).First();
            dc.flightDetails.DeleteOnSubmit(row);
            return View(row);
        }

        public ActionResult insert()
        {
            string destination = Request["Destination"];
            string date = Request["Date"];
            string departure = Request["Departure"];
            string airline = Request["Airline"];
            string time = Request["Time"];
            string eSeats = Request["eSeats"];
            string bSeats = Request["bSeats"];

            int e = Int32.Parse(eSeats);
            int b = Int32.Parse(bSeats);

            flightDetails temp = new flightDetails();
            temp.Airline = airline;
            temp.Departure = departure;
            temp.Date = date;
            temp.Destination = destination;
            temp.Time = time;
            temp.eSeatsAvailable = e;
            temp.bSeatsAvailable = b;
           
            DataClasses1DataContext dc = new DataClasses1DataContext();
            dc.flightDetails.InsertOnSubmit(temp);
            dc.SubmitChanges();

            return RedirectToAction("admin");
        }

        public ActionResult bookNow()
        {
            string Id = Request["id"];
            int ID = Int32.Parse(Id);
            DataClasses1DataContext dc = new DataClasses1DataContext();
            var temp = dc.flightDetails.Where(c => c.Id == ID).First();

            return View(temp);
        }

        public ActionResult book()
        {
            string Id = Request["id"];
            string eseat = Request["eseat"];
            string bseat = Request["bseat"];

            int ID = Int32.Parse(Id);
            int e = Int32.Parse(eseat);
            int b = Int32.Parse(bseat);

            DataClasses1DataContext dc = new DataClasses1DataContext();
            var temp = dc.flightDetails.Where(c => c.Id == ID).First();
            temp.eSeatsAvailable = temp.eSeatsAvailable - e;
            temp.bSeatsAvailable = temp.bSeatsAvailable - b;
            dc.SubmitChanges();

            return View();
        }

        public ActionResult update()
        {
            string destination = Request["Destination"];
            string date = Request["Date"];
            string departure = Request["Departure"];
            string airline = Request["Airline"];
            string time = Request["Time"];
            string eSeats = Request["eSeats"];
            string bSeats = Request["bSeats"];
            string id = Request["id"];

            int ID = Int32.Parse(id);
            int e = Int32.Parse(eSeats);
            int b = Int32.Parse(bSeats);

            DataClasses1DataContext dc = new DataClasses1DataContext();
            var temp = dc.flightDetails.Where(c => c.Id == ID).First();
            temp.Airline = airline;
            temp.Departure = departure;
            temp.Date = date;
            temp.Destination = destination;
            temp.Time = time;
            temp.eSeatsAvailable = e;
            temp.bSeatsAvailable = b;

            dc.SubmitChanges();

            return RedirectToAction("admin");
        }
    }
}