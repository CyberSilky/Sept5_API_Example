using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sept5_API_Example.Models 
    //models define the data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public double Price { get; set; }
        public double Tax { get; set; }


    }
}
