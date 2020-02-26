using MVCViews;
using Restaurant.DAL;
using Restaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCView.Controllers
{
    [HandleError]
    public class RestaurantDetailsController : Controller
    {
        // GET: RestaurantDetails
        RestaurantRepositary restaurantRepositary = new RestaurantRepositary();
       
        public ViewResult Index()
        {
            IEnumerable<RestaurantEntity> restaurants = restaurantRepositary.DisplayRestaurant();
            return View(restaurants);
        }
        [ErrorHandler]
        
        public ViewResult ErrorHandeling()
        {
            throw new Exception("Sorry this content is missing");
        }
        
        public ViewResult RestaurantDetailsDisplay()
        {
            IEnumerable<RestaurantEntity> restaurants = restaurantRepositary.DisplayRestaurant();
            ViewBag.RestaurantDetails = restaurants;
            return View();
        }

        public ActionResult ViewDetails()
        {
            RestaurantRepositary restaurantRepositary = new RestaurantRepositary();
            IEnumerable<RestaurantEntity> restaurants = restaurantRepositary.DisplayRestaurant();
            ViewData["RestaurantDetails"] = restaurants;
            return View();
        }
        public ActionResult ViewAllDetails()
        {
            IEnumerable<RestaurantEntity> restaurants = restaurantRepositary.DisplayRestaurant();
            TempData["Restaurant"] = restaurants;
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreateUpdate([Bind(Exclude ="Location")]RestaurantEntity restaurantEntity)
        {
            restaurantRepositary.AddRestaurant(restaurantEntity);
            TempData["Message"] = "Restaurant Added";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string restaurantName)
        {
            RestaurantEntity restaurant = restaurantRepositary.GetRestaurant(restaurantName);
            return View(restaurant);
        }
        public ActionResult Delete(string restaurantName)
        {
            restaurantRepositary.DeleteRestaurant(restaurantName);
            TempData["Message"] = "Restaurant deleted";
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ActionName("Update")]
        public ActionResult UpdateTry([Bind(Include = "RestaurantName,RestaurantType")] RestaurantEntity restaurantEntity)
        {
            restaurantRepositary.UpdateRestaurant(restaurantEntity);
            TempData["Message"] = "Restaurant Updated";
            return RedirectToAction("Index");
        }
       

    }
}