using FoodDeliveryBusiness.DTO;
using System.Collections.Generic;

namespace FoodDeliveryBusiness.Interfaces
{
    public interface IConvertToJson
    {
        List<RestaurantDto> ConvertJSON(string[] lines);
    }
}
