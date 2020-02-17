using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Entity;

namespace Restaurant.DAL
{
    public class RestaurantRepositary
    {
        static List<RestaurantEntity> restaurantEntities = new List<RestaurantEntity>();

        static RestaurantRepositary()
        {
            RestaurantEntity restaurantEntity = new RestaurantEntity("Chennise", "Indian", "Sarada college,Salem");
            restaurantEntities.Add(restaurantEntity);
            restaurantEntity = new RestaurantEntity("Taj", "Chinese", "Bus-Stand,Erode");
            restaurantEntities.Add(restaurantEntity);
        }
        public IEnumerable<RestaurantEntity> DisplayRestaurant()
        {
            return restaurantEntities;
        }
        public void AddRestaurant(RestaurantEntity restaurantEntity)
        {
            restaurantEntities.Add(restaurantEntity);
        }
        public RestaurantEntity GetRestaurant(string restaurantName)
        {
            return restaurantEntities.Find(id => id.RestaurantName == restaurantName);
        }
        public void DeleteRestaurant(string restaurantName)
        {
            RestaurantEntity restaurant = GetRestaurant(restaurantName);
            if (restaurant != null)
            {
                restaurantEntities.Remove(restaurant);
            }
        }
        public void UpdateRestaurant(RestaurantEntity entity)
        {
            RestaurantEntity restaurantEntity = GetRestaurant(entity.RestaurantName);
            restaurantEntity.RestaurantType = entity.RestaurantType;
            restaurantEntity.Location = entity.Location;
        }
    }
}
