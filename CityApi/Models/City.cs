using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityApi.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public int CityCode { get; set; } 
    }
}