using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CityApi.Models
{
    public class Result
    {
        public string controller { get; set; }
        public string action { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
    }
    public class Result<T> : Result
    {
        public T data { get; set; }
    }
}