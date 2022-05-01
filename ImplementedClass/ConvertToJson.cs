using FoodDeliveryBusiness.DTO;
using FoodDeliveryBusiness.ErrorLogging;
using FoodDeliveryBusiness.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryBusiness.ImplementedClass
{
    public class ConvertToJson : IConvertToJson
    {
        public List<RestaurantDto> ConvertJSON(string[] lines)
        {
            if (lines == null)
                return null;
            var listOfStrings = lines.Select(s => s.Replace("\"", string.Empty).Trim()).ToList();
            listOfStrings.RemoveAll(p => string.IsNullOrEmpty(p));
            var x = listOfStrings.ToArray();
            var csv = new List<string[]>();
            foreach (string line in x)
            {
                csv.Add(line.Split(','));
            }
            var properties = lines[0].Split(',');
            var listObjResult = new List<Dictionary<string, string>>();
            for (int i = 1; i < lines.Length; i++)
            {
                try
                {
                    var objResult = new Dictionary<string, string>();
                    for (int j = 0; j < properties.Length; j++)
                    {
                        objResult.Add(properties[j], csv[i][j]);
                    }
                    listObjResult.Add(objResult);
                }
                catch (Exception e)
                {
                    Logging.Message(e.Message, lines[i].ToString(), i);
                }
            }
            var tt = JsonConvert.SerializeObject(listObjResult, Formatting.Indented);
            var obj = JsonConvert.DeserializeObject<List<RestaurantDto>>(tt);
            return obj;
        }
    }
}
