using FoodDeliveryBusiness.Interfaces;
using System;
using System.IO;

namespace FoodDeliveryBusiness.ImplementedClass
{
    public class FileRead : IFileRead
    {
        string[] content;
        public string[] ReadFile(string textFile)
        {
            //string[] content;
            try
            {
                content = File.ReadAllLines(textFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            return content;
        }


    }
}
