using assign4_413.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace assign4_413.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // We instantiate the 5 default restaurants here
            RestaurantList.InstantiateWithStartData();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<string> restaurList = new List<string>();
            ///
            /// I don't know why we were supposed to do an array here, and return it as strings in the frontend....
            /// It actually looks really ugly to do the full string concats like we were shown to do in the video etc., 
            /// But doing it anyway. However, I could easily replace this with the other functions I made for the class etc.
            /// Literally adds about 15 lines of code.
            ///
            foreach (Restaurant restaurant in RestaurantList.Top5RestaurantsArray)
            {
                if (restaurant.WebsiteLink is null)
                {
                    restaurant.WebsiteLink = "Coming Soon.";
                }
                restaurList.Add("#: "
                    + restaurant.Rank + ", "
                    + restaurant.RestaurantName + ", "
                    + restaurant.FavoriteDish + ", "
                    + restaurant.Address + ", "
                    + restaurant.PhoneNumber + ", "
                    + restaurant.WebsiteLink);
            }
            return View(restaurList);
        }

        [HttpGet]
        public IActionResult ViewSuggestions()
        {
            List<string> suggRestaurList = new List<string>();
            /// Same comment as above.
            /// 
            foreach (RestaurantSuggestion restaurant in RestaurantList.RestaurantSuggestionsArray)
            {
                if (restaurant.FavoriteDish is null)
                {
                    restaurant.FavoriteDish = "It's all tasty!";
                }
                suggRestaurList.Add(
                    restaurant.Name + ", "
                    + restaurant.RestaurantName + ", "
                    + restaurant.PhoneNumber + ", "
                    + restaurant.FavoriteDish);
            }
            return View(suggRestaurList);
        }

        [HttpGet]
        public IActionResult EnterRestaurant()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterRestaurant(RestaurantSuggestion restaurantSuggestion)
        {
            Debug.WriteLine(restaurantSuggestion.Name);
            Debug.WriteLine(restaurantSuggestion.RestaurantName);
            Debug.WriteLine(restaurantSuggestion.PhoneNumber);
            Debug.WriteLine(restaurantSuggestion.FavoriteDish);
            Debug.WriteLine(restaurantSuggestion.FavoriteDish is null);

            if (ModelState.IsValid)
            {
                RestaurantList.AddRestaurantSuggestion(restaurantSuggestion);
            }
            return View();
        }

        [HttpGet("Legal")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
