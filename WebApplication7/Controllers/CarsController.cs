using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication7.Models;
using WebApplication7.Repository;

namespace WebApplication7.Controllers
{
    public class CarsController : Controller
    {
        private GenericRepository<Car> repo;

        public CarsController()
        {
            repo = new GenericRepository<Car>();
        }

        public CarsController(GenericRepository<Car> _db)
        {
            repo = _db;
        }

        // GET: Cars
        public ActionResult Index()
        {
            return View(repo.GetOverview().ToList());
        }

        // GET: Cars/Details/5
        public ActionResult Details(int? id)
        {
            var car = repo.GetDetail(p => p.CarId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Cars/Create
        public ActionResult Create()
        {
            return View();
        }

        
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(Car car)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repo.Add(car);
        //        repo.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(car);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
               await repo.AddAsync(car);
               await repo.SaveAsync();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            var car = repo.GetDetail(p => p.CarId == id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        //// POST: Cars/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Car car = repo.GetDetail(p => p.CarId == id);
        //    repo.Repository<Car>().Delete(car);
        //    repo.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var car = repo.GetDetail(p => p.CarId == id);
            await repo.DeleteAsync(car);
            await repo.SaveAsync();
            return RedirectToAction("Index");
        }


    }
}
