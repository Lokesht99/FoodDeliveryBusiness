using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryBusiness.ErrorLogging
{
    public class Logging
    {
        public static void Message(string msg, string data, int i)
        {
            ErrorLog errorLog = new ErrorLog
            {
                message = msg,
                Data = data,
                LineNumber = i
            };
            try
            {
                using (StreamWriter writer = File.AppendText(@"C:\Users\tunuguntla.lokesh\source\MVC Demos\Food_Err.txt"))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(errorLog));
                    //writer.WriteLine("Line Number: " + i + "\n" + "Data: " + dt + "\n" + "Error Message: " + msg + "\n" + "===================================" + "\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }
    }

    public class ErrorLog
    {
        public int LineNumber { get; set; }
        public string message { get; set; }
        public string Data { get; set; }
    }
}
