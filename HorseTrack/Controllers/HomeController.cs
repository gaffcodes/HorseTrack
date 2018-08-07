using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HorseTrack.Models;
using HorseTrack.Models.DBModels;
using HorseTrack.Data;

namespace HorseTrack.Controllers
{
    public class HomeController : Controller
    {
        DataController data;
        //CustomerRouteModel custModel;
        //HorseRouteModel horseModel;
        //InventoryModel invModel;

        public HomeController()
        {
            data = DataController.Data;
        }

        public IActionResult Index()
        {
            return View(data);
        }

        public IActionResult Customers()
        {
            return PartialView(data);
        }

        public IActionResult CustomerInfo([FromRoute] int custID)
        {
            return PartialView("Information", data.Users.Find(cust => cust.ID == custID));
        }

        public IActionResult Horses()
        {
            return PartialView(data);
        }

        public IActionResult Inventory()
        {
            return PartialView();
        }
    }
}
