using IsuCorpTest.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using IsuCorpTest.Utilities;

namespace IsuCorpTest.Controllers
{
    public class ReservationController : Controller
    {
        private IsuCorpModel dbContext;

        public ReservationController()
        {
            dbContext = new IsuCorpModel();
        }

        // GET: Reservation
        public ActionResult Index()
        {
            var reservationList = dbContext.Reservations.ToList();
            ViewBag.pageCout = (reservationList.Count / 10) + 1;
            ViewBag.selectedPage = 1;
            return View(reservationList);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            var contactTypes = dbContext.ContactTypes.ToList().Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.ContacTypeName });
            ViewBag.ContactTypeList = contactTypes;
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbContext.Reservations.Add(reservation);
                    dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            var reservation = dbContext.Reservations.Find(id);
            var contactTypes = dbContext.ContactTypes.ToList().Select(item => new SelectListItem() { Value = item.Id.ToString(), Text = item.ContacTypeName, Selected = item.Id == reservation.ContactTypeId });
            ViewBag.ContactTypeList = contactTypes;
            return View(reservation);
        }

        // POST: Reservation/Edit/5
        [HttpPost]
        public ActionResult Edit(Reservation reservation)
        {
            try
            {
                var reservationContext = dbContext.Reservations.Attach(reservation);

                if (reservationContext == null)
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
                else
                {
                    dbContext.Entry(reservationContext).State = System.Data.Entity.EntityState.Modified;
                    dbContext.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            var reservation = dbContext.Reservations.Find(id);
            dbContext.Reservations.Remove(reservation);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Order Funtions
        public ActionResult OrderBy(string orderType, int pageNumber)
        {
            var sorter = EntitySorter<Reservation>.SortExpression(String.IsNullOrEmpty(orderType) ? "BirthDate asc" : orderType);
            var orderReservations = sorter.Sort(dbContext.Reservations).ToList();
            var reservationCount = 0;
            var reservations = orderReservations.GetPage(pageNumber, 10, out reservationCount);
            
            ViewBag.OrderTypeSelected = orderType;
            ViewBag.selectedPage = pageNumber;
            ViewBag.pageCout = (orderReservations.Count / 10)+1;

            return View("Index", reservations);
        }

        // Lenguage Funtions
        public ActionResult LanguageOptions(string language)
        {
            if (language != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
            }

            var languageCookie = new HttpCookie("languageCookie") { Value = language };
            this.Response.Cookies.Add(languageCookie);

            return RedirectToAction("Index");
        }

        // POST: Reservation/Ranking
        [HttpPost]
        public JsonResult PutRanking(int id, int value)
        {
            var reservation = dbContext.Reservations.Find(id);
            reservation.Ranking = value;
            dbContext.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return Json(new { status = true });

        }

        [HttpPost]
        public JsonResult PutFavorite(int id, bool value)
        {
            var reservation = dbContext.Reservations.Find(id);
            reservation.isFavorite = value;
            dbContext.Entry(reservation).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
            return Json(new { status = "success", reservation.isFavorite });

        }
        [HttpGet]
        public ActionResult Paginator(int pageNumber, string orderType)
        {
            var sorter = EntitySorter<Reservation>.SortExpression(String.IsNullOrEmpty(orderType) ? "BirthDate asc" : orderType);
            var reservationOrderList = sorter.Sort(dbContext.Reservations).ToList();
            var reservationCount = 0;
            var reservations = reservationOrderList.GetPage(pageNumber, 10, out reservationCount);

            ViewBag.pageCout = (reservationCount/10) +1;
            ViewBag.selectedPage = pageNumber;
            ViewBag.OrderTypeSelected = orderType;

            return View("Index", reservations);
        }

    }
}
