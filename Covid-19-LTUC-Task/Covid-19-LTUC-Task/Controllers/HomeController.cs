using Covid_19_LTUC_Task.Models;
using CovidRepo.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountries _Record;
       
        public HomeController(ILogger<HomeController> logger , ICountries Record)
        {
            _Record = Record;
            _logger = logger;
        }

        public IActionResult Index()
        {

            //var client = new RestClient("https://api.covid19api.com/summary");
            //var Request = new RestRequest();
            //Request.Method = Method.Get;
            //var response = client.Get(Request);
            //if (response.IsSuccessful)
            //{
            //    Record res = JsonConvert.DeserializeObject<Record>(response.Content);
            //}
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //[HttpPost]
        //[Route("Record/Create/{Data}")]
        //public async Task<IActionResult> Create(Record Data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _Record.CreateCountries(Data);
        //        return RedirectToAction(nameof(Index));

        //    }
        //    return View(Data);
        //}
    }
}
