using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Training4.Models;

namespace Training4.Controllers
{
    public class TrainingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string trainingRating, string searchString, string sortOrder, int? page)
        {
            ViewBag.currentSort = sortOrder;
            var RatingList = new List<Decimal>(5) { 5, 4, 3, 2, 1 };
            ViewBag.trainingRating = new SelectList(RatingList, trainingRating);
            ViewBag.search = searchString;
            ViewBag.rating = trainingRating;
            ViewBag.StarSort = String.IsNullOrEmpty(sortOrder) ? "star_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TopicSort = sortOrder == "Topic" ? "topic_desc" : "Topic";
            ViewBag.page = page.HasValue ? page : 0;
            ViewBag.reviews = from t in db.Reviews
                                  select t;
            var trainings = from t in db.Trainings
                            select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainings = trainings.Where(s => s.Course.Contains(searchString) || s.Topic.Contains(searchString) || s.Location.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(trainingRating))
            {
                decimal y = Decimal.Parse(trainingRating);
                trainings = trainings.Where(x => x.Stars == y);
            }
            switch (sortOrder) {
                case "star_desc":
                    trainings = trainings.OrderBy(t => t.Stars).ThenByDescending(t=>t.Date);
                    break;
                case "Date":
                    trainings = trainings.OrderByDescending(t => t.Date).ThenByDescending(t=>t.Stars);
                    break;
                case "date_desc":
                    trainings = trainings.OrderBy(t => t.Date).ThenByDescending(t=>t.Stars);
                    break;
                case "Topic":
                    trainings = trainings.OrderBy(t => t.Topic).ThenByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
                case "topic_desc":
                    trainings = trainings.OrderByDescending(t => t.Topic).ThenByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
                default:
                    trainings = trainings.OrderByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
        }
            return View(trainings.ToList());
        }
        // GET: Index 2 (Condensed View)
        public ActionResult Index2(string trainingRating, string searchString, string sortOrder, int? page)
        {
            ViewBag.currentSort = sortOrder;
            var RatingList = new List<Decimal>(5) { 5, 4, 3, 2, 1 };
            ViewBag.trainingRating = new SelectList(RatingList, trainingRating);
            ViewBag.search = searchString;
            ViewBag.rating = trainingRating;
            ViewBag.StarSort = String.IsNullOrEmpty(sortOrder) ? "star_desc" : "";
            ViewBag.DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.TopicSort = sortOrder == "Topic" ? "topic_desc" : "Topic";
            ViewBag.page = page.HasValue ? page : 0;

            var trainings = from t in db.Trainings
                            select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainings = trainings.Where(s => s.Course.Contains(searchString) || s.Topic.Contains(searchString) || s.Location.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(trainingRating))
            {
                decimal y = Decimal.Parse(trainingRating);
                trainings = trainings.Where(x => x.Stars == y);
            }
            switch (sortOrder)
            {
                case "star_desc":
                    trainings = trainings.OrderBy(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
                case "Date":
                    trainings = trainings.OrderByDescending(t => t.Date).ThenByDescending(t => t.Stars);
                    break;
                case "date_desc":
                    trainings = trainings.OrderBy(t => t.Date).ThenByDescending(t => t.Stars);
                    break;
                case "Topic":
                    trainings = trainings.OrderBy(t => t.Topic).ThenByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
                case "topic_desc":
                    trainings = trainings.OrderByDescending(t => t.Topic).ThenByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
                default:
                    trainings = trainings.OrderByDescending(t => t.Stars).ThenByDescending(t => t.Date);
                    break;
            }
            return View(trainings.ToList());
        }

        // GET: Index1
        public ActionResult Index1(string trainingRating, string searchString)
        {
            var RatingList = new List<Decimal>(5) { 1, 2, 3, 4, 5 };
            var RatingQry = from d in db.Trainings
                            orderby d.Stars
                            select d.Stars;
            ViewBag.trainingRating = new SelectList(RatingList);



            var trainings = from t in db.Trainings
                            select t;
            if (!String.IsNullOrEmpty(searchString))
            {
                trainings = trainings.Where(s => s.Course.Contains(searchString)||s.Topic.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(trainingRating))
            {
                decimal y = Decimal.Parse(trainingRating);
                trainings = trainings.Where(x => x.Stars == y);
            }
            trainings = trainings.OrderByDescending(t => t.Stars).ThenBy(t => t.Date);
            return View(trainings.ToList());
        }

        // GET: Trainings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // GET: Trainings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Office,Role,Date,Topic,Course,Format,Time,Url,Price,CEU,Contractor,Location,Instructor,Stars,Review,Recommend")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training);
        }
        public ActionResult Create1()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create1([Bind(Include = "ID,Office,Role,Date,Topic,Course,Format,Time,Url,Price,CEU,Contractor,Location,Instructor,Stars,WReview,Recommend")] Training training)
        {
            if (ModelState.IsValid)
            {
                if (training.Url.Contains("http://"))
                {
                    training.Url = training.Url.Substring(7);
                }
                else if (training.Url.Contains("https://"))
                {
                    training.Url = training.Url.Substring(8);
                }
                Review review = new Review();
                review.R = training.WReview;
                db.Trainings.Add(training);
                db.SaveChanges();
                review.Training_ID = training.ID;
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(training);
        }
        public ActionResult CreateSurvey()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSurvey([Bind(Include = "ID,Office,Role,Date,Topic,Course,Format,Time,Url,Price,CEU,Contractor,Location,Instructor,Stars,WReview,Recommend")] Training training)
        {
            if (ModelState.IsValid)
            {
                if (training.Url.Contains("http://"))
                {
                    training.Url = training.Url.Substring(7);
                }
                else if (training.Url.Contains("https://"))
                {
                    training.Url = training.Url.Substring(8);
                }
                db.Trainings.Add(training);
                db.SaveChanges();
                int id = training.ID;
                return RedirectToAction("SurveyCreated",new { id = id });
            }

            return View(training);
        }
        public ActionResult SurveyCreated(int? id)
        {
            ViewBag.ID = id;
            return View();
        }
        public ActionResult Howto()
        {
            return View();
        }
        public ActionResult Survey(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            ModelState.Clear();
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Survey([Bind(Include = "ID,Office,Role,Date,Topic,Course,Format,Time,Url,Price,CEU,Contractor,Location,Instructor,Stars,WReview,Recommend")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                decimal temp = training.Stars;
                decimal temp1=1;
                foreach (Review x in db.Reviews)
                {
                    if (x.Training_ID == training.ID)
                    {
                        temp1++;
                        temp += x.Stars;
                    }
                }
                Review review = new Review();
                review.Stars = training.Stars;
                training.Stars = temp / temp1;
                review.R = training.WReview;
                training.WReview = null;
                review.Training_ID = training.ID;
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Trainings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Office,Role,Date,Topic,Course,Format,Time,Url,Price,CEU,Contractor,Location,Instructor,Stars,Review,Recommend")] Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(training);
        }

        // GET: Trainings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            db.Trainings.Remove(training);
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
    }
}
