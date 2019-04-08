using Organizer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Organizer.Controllers
{
    public class AppointmentController : Controller
    {
        private OrganizerDbContext db = new OrganizerDbContext();
        // GET: Appointment
        public ActionResult ListAppointments(int? Page)
        {
            List<Appointment> appointments = db.Appointments 
               .Include(a => a.Broker)
               .Include(a => a.Customer)
               .ToList();
            return View(appointments.ToList().ToPagedList(Page ?? 1, 3));
        }
        public ActionResult AddAppointment()
        {
            //permet d'afficher les données voulues dans la dropdownlist présente dans la vue
            ViewBag.BrokerID = new SelectList(db.Brokers, "BrokerID", "FullName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAppointment([Bind(Include = "AppointmentID, DateHour, BrokerID, CustomerID, Subject")] Appointment appointment)
        {
            var queryResult = db.Appointments.SingleOrDefault(a => (a.BrokerID == appointment.BrokerID && a.DateHour == appointment.DateHour) || (a.CustomerID == appointment.CustomerID && a.DateHour == appointment.DateHour));
            if (queryResult != null)
            {
                ModelState.AddModelError("DateHour", "le rendez vous est déjà pris");
            }
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.BrokerID = new SelectList(db.Brokers, "BrokerID", "FullName");
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName");
            //Il faut absolument mettre index et home pour pouvoir faire le bon chemin jusque index etant donné que ici c'est appointment sinon erreur à l'envoie du rendez vous
            return View("Index", "Home");
        }
        public ActionResult DetailsAppointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            //via le viewBag on va chercher la liste avec l'id, le texte et si la personne existe, il selectionne la personne enregistrer dans la base de donné
            ViewBag.BrokerID = new SelectList(db.Brokers, "BrokerID", "FullName", appointment.BrokerID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", appointment.CustomerID);
            return View(appointment);
        }
        public ActionResult EditAppointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrokerID = new SelectList(db.Brokers, "BrokerID", "FullName", appointment.BrokerID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", appointment.CustomerID);
            return View(appointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAppointment([Bind(Include = "AppointmentID, DateHour, BrokerID, CustomerID, Subject")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.BrokerID = new SelectList(db.Brokers, "BrokerID", "FullName", appointment.BrokerID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FullName", appointment.CustomerID);
            return View(appointment);
        }
        public ActionResult DeleteAppointment(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
        [HttpPost, ActionName("DeleteAppointment")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}