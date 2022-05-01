using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryBusiness.Interfaces
{
    public interface IFileRead
    {
        string[] ReadFile(string textFile);
    }
}
