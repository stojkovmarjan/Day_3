﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{

    public class EmployeeController : Controller
    {
        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }

        [NonAction]
        public string SimpleMethod()
        {
            return "Hi, I am not action method";
        }


        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            
            return View("Index", employeeListViewModel);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
    public ActionResult SaveEmployee(Employee e, string BtnSubmit)
    {
        switch (BtnSubmit)
        {
            case "Save Employee":
                if (ModelState.IsValid)
                {
                    EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                    empBal.SaveEmployee(e);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("CreateEmployee");
                }
            case "Cancel":
                return RedirectToAction("Index");
        }
        return new EmptyResult();
    }
        //public ActionResult SaveEmployee([ModelBinder(typeof(MyEmployeeModelBinder))]Employee e, string BtnSubmit)
        //{
        //    switch (BtnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index");
        //    }
        //    return new EmptyResult();
        //}
    }
    //public class MyEmployeeModelBinder : DefaultModelBinder
    //{
    //    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //    {
    //        Employee e = new Employee();
    //        e.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FName"];
    //        e.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LName"];
    //        e.Salary = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["Salary"]);
    //        return e;
    //    }
    //}
}