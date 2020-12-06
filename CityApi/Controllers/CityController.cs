using CityApi.Data;
using CityApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CityApi.Controllers
{
    public class CityController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCity([FromUri] string param)
        {
            Query query = new Query();
            DataTable dt = new DataTable();
            dt = query.GetCity(param);
            List<City> city = new List<City>();
            foreach (DataRow item in dt.Rows)
            {
                city.Add(new City
                {
                    CityName = item["CityName"].ToString(),
                    CityCode = Convert.ToInt32(item["CityCode"].ToString()),
                    Id = Convert.ToInt32(item["Id"].ToString())
                });
            }

            Result<List<City>> sonuc = new Result<List<City>>()
            {
                action = "GetCity",
                controller = "City",
                error = false,
                message = "",
                data = city.ToList()
            };

            return Ok(sonuc);
        }
    }
}
