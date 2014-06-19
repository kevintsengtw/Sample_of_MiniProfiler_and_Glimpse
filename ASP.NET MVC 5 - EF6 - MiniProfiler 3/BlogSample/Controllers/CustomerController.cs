using System.Linq;
using System.Web.Mvc;
using BlogSample.Models;
using PagedList;

namespace BlogSample.Controllers
{
    public class CustomerController : Controller
    {
        private Northwind db = new Northwind();

        private int pageSize = 10;

        public ActionResult Index(int page = 1)
        {
            var result = GetPagedList(page, pageSize);
            return View(result);
        }

        private IPagedList<Customer> GetPagedList(int page, int pageSize)
        {
            page = page < 1 ? 1 : page;

            var query = db.Customers.OrderBy(x => x.CustomerID);

            return query.ToPagedList(page, pageSize);
        }
    }
}