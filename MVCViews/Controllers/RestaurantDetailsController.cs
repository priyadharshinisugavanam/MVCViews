using Restaurant.DAL;
using Restaurant.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCView.Controllers
{
    public class RestaurantDetailsController : Controller
    {
        // GET: RestaurantDetails
        RestaurantRepositary restaurantRepositary = new RestaurantRepositary();
        public ViewResult Index()
        {

            IEnumerable<RestaurantEntity> restaurants = restaurantRepositary.DisplayRestaurant();
            return View(restaurants);
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
        public ActionResult CreateUpdate()
        {
            RestaurantEntity restaurantEntity = new RestaurantEntity();
            TryUpdateModel(restaurantEntity);
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
        public ActionResult UpdateTry()
        {
            RestaurantEntity restaurantEntity = new RestaurantEntity();
            UpdateModel(restaurantEntity);
            restaurantRepositary.UpdateRestaurant(restaurantEntity);
            TempData["Message"] = "Restaurant Updated";
            return RedirectToAction("Index");
        }

    }
}