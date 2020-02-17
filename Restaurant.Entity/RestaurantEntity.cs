using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Entity
{
    public class RestaurantEntity
    {
        public string RestaurantName { get; set; }
        public string RestaurantType { get; set; }
        public string Location { get; set; }

        public RestaurantEntity(string restaurantName, string restaurantType, string location)
        {
            this.RestaurantName = restaurantName;
            this.RestaurantType = restaurantType;
            this.Location = location;
        }
        public RestaurantEntity()
        {

        }
    }
}
