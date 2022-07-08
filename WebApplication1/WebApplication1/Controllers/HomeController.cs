using BisunessLayer.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using BisunessLayer;
using PresentationLayer.Models;
using PresentationLayer;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public HomeController(DataManager dataManager)
        {

            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();
            return View(_dirs);
        }
    }
}