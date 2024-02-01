using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppViewBagViewDataTempData.Models;

namespace WebAppViewBagViewDataTempData.Controllers
{
    public class EmpController : Controller
    {
        static List<Emp> listEmp = new List<Emp>
        {
            new Emp{ Id=1,Name="Aarthi",Salary=98000,Designation="Manager"},
            new Emp{ Id=2,Name="Abi",Salary=86000,Designation="Tester"},
            new Emp{ Id=3,Name="Charu",Salary=75000,Designation="Developer"},
            new Emp{ Id=4,Name="Srini",Salary=98000,Designation="Manager"},
            new Emp{ Id=5,Name="Lachu",Salary=92000,Designation="Manager"},
        };
        // GET: Emp
        public ActionResult Index()
        {
            ViewBag.Msg = "Welcome to Employee Management";
            ViewBag.noEmp = listEmp.Count;
            return View(listEmp);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["msg"] = "Employee Registration";
            return View(new Emp());
        }
        [HttpPost]
        public ActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                listEmp.Add(emp);
                TempData["tempmsg"] = "New Employee Registration Success";
                return RedirectToAction("Index");
            }
            else
            {
                return View(emp);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Emp emp = listEmp.SingleOrDefault(e => e.Id == id);

            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Emp emp = listEmp.SingleOrDefault(e => e.Id == id);
            if (emp != null)
            {
                listEmp.Remove(emp);
            }
            return RedirectToAction("Index");
            

        }

    }
}