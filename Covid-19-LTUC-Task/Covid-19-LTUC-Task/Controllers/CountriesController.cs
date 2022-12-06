using Covid_19_LTUC_Task.Models;
using CovidRepo.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountries _countries;
        public IActionResult Index()
        {
            Record result = new Record();
            var client = new RestClient("https://api.covid19api.com/summary");
            var Request = new RestRequest();
            Request.Method = Method.Get;
            var response = client.Get(Request);
            if (response.IsSuccessful)
            {
                 result = JsonConvert.DeserializeObject<Record>(response.Content);
            }
            
            return View(result.Countries);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Guid ID)
        {
            Record result = new Record();
            //Guid id = new Guid();
            var client = new RestClient("https://api.covid19api.com/summary");
            var Request = new RestRequest();
            Request.Method = Method.Get;
            var response = client.Get(Request);
            if (response.IsSuccessful)
            {
                result = JsonConvert.DeserializeObject<Record>(response.Content);
            }
            Countries country = result.Countries.Where(x => x.ID == ID).FirstOrDefault();
            if (ModelState.IsValid)
            {
                await _countries.CreateCountries(country);
            }
            return RedirectToAction(nameof(Index));
            
        }
    }
}
