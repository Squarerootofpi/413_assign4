using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assign4_413.Models
{
    public class RestaurantSuggestion
    {
        /// <summary>
        /// Name of the person that submitted suggestion
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string RestaurantName { get; set; }

        // This one we allow optional and nullable.
        public string? FavoriteDish { get; set; } = "It's all tasty!";

        [Required(AllowEmptyStrings = false, ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

    }
}
