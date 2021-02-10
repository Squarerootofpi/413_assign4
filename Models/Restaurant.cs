using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assign4_413.Models
{
    public class Restaurant
    {
        /// <summary>
        /// Constructor. We protect against nulls by making sure to throw errors
        /// if any are set innappropriately. 
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="restaurantName"></param>
        /// <param name="favoriteDish"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="websiteLink"></param>
        public Restaurant(
            int rank, string restaurantName, string address, 
            string favoriteDish = "It’s all tasty!", string phoneNumber = "555-555-5555", string websiteLink = "Coming soon.")
        {
            Rank = rank;
            RestaurantName = restaurantName ?? throw new ArgumentNullException(nameof(restaurantName));
            FavoriteDish = favoriteDish ?? throw new ArgumentNullException(nameof(favoriteDish));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
            WebsiteLink = websiteLink ?? throw new ArgumentNullException(nameof(websiteLink));
        }

        /// <summary>
        /// Rank is readonly after creating the class
        /// The rank of what the restaurant is.
        /// </summary>
        public int Rank { get; }

        public string RestaurantName { get; set; }

        public string FavoriteDish { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public string WebsiteLink { get; set; } = "Coming Soon.";
    }
}
