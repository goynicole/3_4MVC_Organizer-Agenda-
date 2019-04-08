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
    public class CustomerController : Controller
    {
        private OrganizerDbContext db = new OrganizerDbContext();
        // GET: Customer
        public ActionResult ListCustomers(string search, int? Page)
        {
            var customerQ = from c in db.Customers select c;
            if (!String.IsNullOrEmpty(search))
            {
                customerQ = customerQ.Where(c => c.Firstname.Contains(search) || c.Lastname.Contains(search));
            }
            List < Customer > customers = customerQ.ToList();
            //permet l'affichage de 3 (correspond à la limite de ligne) clients au niveaux de la pagination
            return View((customers.ToList().ToPagedList(Page ?? 1,3)));
        }
        // GET: Customer
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//Empêche l'attaque par validation de formulaire
        public ActionResult AddCustomer([Bind(Include = "Firstname, Lastname, Mail, PhoneNumber, Budget")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);//insertion dans la base de donnée
                db.SaveChanges();//Sauvegarde de la base de donnée avec les nouvelles datas
                return RedirectToAction("ListCustomers");//une fois l'insertion réussi, redirection vers la vue ListCustomers
            }
            return View();
        }
        public ActionResult ProfilCustomer(int? id)
        {
            // Condition si l'id n'est pas correct
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //On demande à récupérer l'id correspondant à la ligne choisi.
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer([Bind(Include = "CustomerID, Firstname, Lastname, Mail, PhoneNumber, Budget")] Customer customer)
        {
            //S'il n'y a pas d'erreur
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;//modification dans la base de données
                db.SaveChanges();//Sauvegarde de la base de données
                return RedirectToAction("ListCustomers");
            }
            return View("ProfilCustomer");
        }
        
        public ActionResult DeleteCustomer(int id)
        {
            Customer CustomerDelete = db.Customers.Find(id);
            db.Entry(CustomerDelete).State = EntityState.Deleted;//suppression dans la base de données
            db.Customers.Remove(CustomerDelete);
            db.SaveChanges();//Sauvegarde de la base de données
            return RedirectToAction("ListCustomers");
        }
    }
}