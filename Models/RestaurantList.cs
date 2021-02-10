using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace assign4_413.Models
{
    /// <summary>
    /// The restaurant and suggestion lists. Has a variety of functions to make it nice for storing and retrieving.
    /// </summary>
    public class RestaurantList
    {
        /// <summary>
        /// The list of restaurants
        /// </summary>
        private static List<Restaurant> restaurants = new List<Restaurant>();
        public static IEnumerable<Restaurant> Restaurants => restaurants;

        public static Restaurant[] RestaurantsArray => restaurants.ToArray();

        /// <summary>
        /// Returns only the top 5 ranking restaurants.
        /// </summary>
        public static IEnumerable<Restaurant> Top5Restaurants => restaurants.FindAll(rest => rest.Rank <= 5);
        public static Restaurant[] Top5RestaurantsArray => Top5Restaurants.ToArray();

        /// <summary>
        /// Lists the restaurant suggestions
        /// </summary>
        private static List<RestaurantSuggestion> restaurantSuggestions = new List<RestaurantSuggestion>();
        public static IEnumerable<RestaurantSuggestion> RestaurantSuggestions => restaurantSuggestions;
        public static RestaurantSuggestion[] RestaurantSuggestionsArray => restaurantSuggestions.ToArray();

        public static void InstantiateWithStartData()
        {
            if (restaurants.Count() == 0 )
            {
                Restaurant r1 = new Restaurant(1, "Cafe Rio", "2244 N University Pkwy, Provo UT", "All of them", "801-375-5133", "caferio.com");
                Restaurant r2 = new Restaurant(2, "5 Guys", "1051 S 750 E, Orem, UT 84097", "All toppings", "801-765-7556", "restaurants.fiveguys.com/1051-south-750-east");
                Restaurant r3 = new Restaurant(3, "McDonald's", "West 1230 North, Provo UT", "Big Mac", "801-374-6909", "mcdonalds.com");
                Restaurant r4 = new Restaurant(4, "Wendy's", "122 E 1230 N St, Provo, UT 84604", "4 for 4", "801-377-8063", "locations.wendys.com");
                Restaurant r5 = new Restaurant(5, "Home", "Provo UT", "Pizza quesadilla", "555-555-555", "jsearch.org");
                restaurants.Add(r1);
                restaurants.Add(r2);
                restaurants.Add(r3);
                restaurants.Add(r4);
                restaurants.Add(r5);
            }
        }
        public static void AddRestaurant(Restaurant restaurant)
        {
            Debug.WriteLine("here!!! Adding restaurant", restaurant);
            restaurants.Add(restaurant);
        }

        public static void AddRestaurantSuggestion(RestaurantSuggestion restaurantSuggestion)
        {
            Debug.WriteLine("here!!! Adding restaurantSuggestion", restaurantSuggestion);
            restaurantSuggestions.Add(restaurantSuggestion);
        }
    }
}
