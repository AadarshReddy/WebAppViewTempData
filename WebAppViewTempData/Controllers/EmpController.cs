using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using WebAppViewTempData.Models;

namespace WebAppViewTempData.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        static List<Emp> listEmp = new List<Emp>
        {
            new Emp {Id=1,Name="Riya",Salary=96000,Designation="Manager"},
            new Emp {Id=2,Name="Vijay",Salary=67000,Designation="HR"},
            new Emp {Id=3,Name="Sunny",Salary=50000,Designation="Developer"}
        };
        public ActionResult Index()
        {
            ViewBag.Msg = "Welcome to Employee ManagmentS";
            ViewBag.noEmp = listEmp.Count;
            return View(listEmp);
        }
        [HttpGet]

        public ActionResult Create() {
            ViewData["msg"] = "New employee Registration";
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
        public ActionResult Delete(int id) {
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