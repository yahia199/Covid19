using Covid_19_LTUC_Task.Models;
using CovidRepo.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Controllers
{
    public class RecordController : Controller
    {
        private readonly ICountries _Record;
        public RecordController(ICountries Record)
        {
            _Record = Record;
        }
        public async Task<IActionResult> Index()
        {
            //List<Record> Record = new List<Record>();
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.DefaultRequestHeaders.Add("Key", "abc@123");
            //    using (var response = await httpClient.GetAsync("https://api.covid19api.com/summary"))
            //    {
            //        string apiResponse = await response.Content.ReadAsStringAsync();
            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            var Recordss = JsonConvert.DeserializeObject<Dictionary<string, object>>(apiResponse);
            //        }
            //        else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //        {
            //            return Unauthorized();
            //        }
            //    }

                var client = new RestClient("https://api.covid19api.com/summary");
                var Request = new RestRequest();
                Request.Method = Method.Get;
                var response = client.Get(Request);
                if(response.IsSuccessful)
                {
                    List<Record>  res = JsonConvert.DeserializeObject<List<Record>>(response.Content);
                }
                return View();
            }
        

                      
        //[HttpPost]
        //[Route("Record/Create/{Data}")]
        //public async Task<IActionResult> Create([FromQuery]Record Data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _Record.CreateCountries(Data);
        //        return RedirectToAction(nameof(Index));

        //    }
        //    return View(Data);
        //}        
        //[HttpPost]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    await _Record.DeleteRecord(id);
        //    return RedirectToAction(nameof(Index));
        //}
    }

}