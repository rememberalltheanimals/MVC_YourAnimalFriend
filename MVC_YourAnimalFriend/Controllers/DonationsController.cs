using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_YourAnimalFriend.Models;
using MVC_YourAnimalFriend.ViewModel;

namespace MVC_YourAnimalFriend.Controllers
{
    public class DonationsController : Controller
    {
        private VolunteerDbContext db = new VolunteerDbContext();

        // GET: Donations
        public ActionResult Index()
        {
            return View(db.Donations.ToList());
        }

        // GET: Donations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);

            List<VolunteerViewModel> volunteers = new List<VolunteerViewModel>();

            foreach(var help in db.HelpingPawsHands.Where(e => e.DonationId == id))
            {
                Volunteer mainVolunteer = db.Volunteers.Where(vol => vol.Id == help.VolunteerId).SingleOrDefault();

                VolunteerViewModel vvm = new VolunteerViewModel();
                vvm.Name = mainVolunteer.Name;
                vvm.Description = mainVolunteer.Description;
                vvm.Type = mainVolunteer.Type;
                vvm.Primary = mainVolunteer.Primary;
                vvm.Secondary = mainVolunteer.Secondary;
                vvm.Visits = help.Visits;
                vvm.Sent = help.Sent;

                volunteers.Add(vvm);
            }

            ViewBag.Volunteers = volunteers;

            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // GET: Donations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Regulary")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Donations.Add(donation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donation);
        }

        // GET: Donations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Regulary")] Donation donation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donation);
        }

        // GET: Donations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Donation donation = db.Donations.Find(id);
            if (donation == null)
            {
                return HttpNotFound();
            }
            return View(donation);
        }

        // POST: Donations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Donation donation = db.Donations.Find(id);
            db.Donations.Remove(donation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Get /Donations/AddVolunteer/5
        public ActionResult AddVolunteer(int? Id)
        {
            if(Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.MainVolunteers = db.Volunteers.ToList();
            ViewBag.Donation = db.Donations.Find(Id);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDonation([Bind(Include = "Name, Visits, Sent, DonationId, FreeHours")] VolunteerViewModel vvm)
        {
            if(vvm != null)
            {
                int VolunteerId = db.Volunteers.Where(vol => vol.Name == vvm.Name).Select(vol => vol.Id).SingleOrDefault();

                HelpingPaws hp = new HelpingPaws();
                hp.DonationId = vvm.DonationId;
                hp.VolunteerId = VolunteerId;
                hp.Visits = vvm.Visits;
                hp.Sent = vvm.Sent;
                hp.FreeHours = vvm.FreeHours;

                db.HelpingPawsHands.Add(hp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(vvm);
        }
    }
}
