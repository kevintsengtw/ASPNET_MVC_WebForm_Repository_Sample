using System.Web.Mvc;
using Sample.Repository.Interface;

namespace Sample.Web.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository r)
        {
            this._repository = r;
        }
        
        public ActionResult Index()
        {
            var employees = this._repository.GetEmployees();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = this._repository.GetOne(id);
            return View(employee);
        }
    }
}
