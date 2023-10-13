using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBS_UILayer.Controllers
{
    public class MainMenuController : Controller
    {
        
        /// Display Home Page
        public IActionResult Home()
        {
            return View();
        }


       
        /// Display Customer Panel
        public IActionResult CustomerPanel()
        {
            return View();
        }


        //Displays Error 404 Page where ever needed
        public IActionResult ErrorPage()
        {
            return View();
        }


    }
}
