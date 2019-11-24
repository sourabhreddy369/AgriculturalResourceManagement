using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgriculturalResourceManagement.Models;
using Newtonsoft.Json;
using System.Net.Http;
using AgriculturalResourceManagement.DataAccess;

namespace NationalParks.Controllers
{
    public class HomeController : Controller
    {

        public ApplicationDbContext dbContext;
        static string BASE_URL = "https://api.ers.usda.gov/data/arms/";
        static string API_KEY = "Lrr804HNAPbzeOMHvQmx7k8M7hedpx8bJzR0hP9e"; //Add your API key here inside ""

        HttpClient httpClient;

        /// <summary>
        ///  Constructor to initialize the connection to the data source
        /// </summary>
        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Add("X-Api-Key", API_KEY);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Method to receive data from API end point as a collection of objects
        /// 
        /// JsonConvert parses the JSON string into classes
        /// </summary>
        /// <returns></returns>
        public Reports GetReports()
        {
            string REPORT_API_PATH = BASE_URL + "report?";
            string reportsData = "";

            Reports reports = null;

            httpClient.BaseAddress = new Uri(REPORT_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(REPORT_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    reportsData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!reportsData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    reports = JsonConvert.DeserializeObject<Reports>(reportsData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return reports;
        }

        public States GetStates()
        {
            string STATE_API_PATH = BASE_URL + "state?";
            string statesData = "";

            States states = null;

            httpClient.BaseAddress = new Uri(STATE_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(STATE_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    statesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!statesData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    states = JsonConvert.DeserializeObject<States>(statesData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return states;
        }

        public Categories GetCategories()
        {
            string CATEGORY_API_PATH = BASE_URL + "category?";
            string categoriesData = "";

            Categories categories = null;

            httpClient.BaseAddress = new Uri(CATEGORY_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(CATEGORY_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    categoriesData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!categoriesData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    categories = JsonConvert.DeserializeObject<Categories>(categoriesData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return categories;
        }

        [HttpPost]
        public IActionResult SurveyData(String test)
        {
            string SURVEYDATA_API_PATH = BASE_URL + "surveydata?";
            string surveyData = "";
            string[] words = test.Split(' ');
            String report = "";
            foreach(String word in words)
            {
                report = report +"+"+word;
            }

            SurveyDatas surveyDatas = null;
            SURVEYDATA_API_PATH = SURVEYDATA_API_PATH + "year=2015&report="+report+"&";
            httpClient.BaseAddress = new Uri(SURVEYDATA_API_PATH);

            // It can take a few requests to get back a prompt response, if the API has not received
            //  calls in the recent past and the server has put the service on hibernation
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(SURVEYDATA_API_PATH).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    surveyData = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                }

                if (!surveyData.Equals(""))
                {
                    // JsonConvert is part of the NewtonSoft.Json Nuget package
                    surveyDatas = JsonConvert.DeserializeObject<SurveyDatas>(surveyData);
                }
            }
            catch (Exception e)
            {
                // This is a useful place to insert a breakpoint and observe the error message
                Console.WriteLine(e.Message);
            }

            return View(surveyDatas);
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }
        public IActionResult Reports()
        {
            HomeController webHandler = new HomeController(dbContext);
            Reports reports = webHandler.GetReports();

            return View(reports);
        }
        public IActionResult States()
        {
            HomeController webHandler = new HomeController(dbContext);
            States states = webHandler.GetStates();

            return View(states);
        }

        public IActionResult Categories()
        {
            HomeController webHandler = new HomeController(dbContext);
            Categories categories = webHandler.GetCategories();

            return View(categories);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PopulateReports()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            Reports report = webHandler.GetReports();
            //Candidates candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            List<Report> cd = report.data;
            foreach (Report cd1 in cd)
            {
                if (dbContext.Report.Where(c => c.id.Equals(cd1.id)).Count() == 0)
                {
                    dbContext.Report.Add(cd1);
                }

            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Reports", report);
        }

        public IActionResult PopulateCategories()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            Categories category = webHandler.GetCategories();
            //Candidates candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            List<Category> cd = category.data;
            foreach (Category cd1 in cd)
            {
                if (dbContext.Category.Where(c => c.id.Equals(cd1.id)).Count() == 0)
                {
                    dbContext.Category.Add(cd1);
                }

            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("Categories", category);
        }

        public IActionResult PopulateStates()
        {
            // Retrieve the companies that were saved in the symbols method
            // List<Candidates> candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            HomeController webHandler = new HomeController(dbContext);
            States state = webHandler.GetStates();
            //Candidates candidate = JsonConvert.DeserializeObject<Candidates>(TempData["Candidates"].ToString());
            List<State> cd = state.data;
            foreach (State cd1 in cd)
            {
                if (dbContext.State.Where(c => c.id.Equals(cd1.id)).Count() == 0)
                {
                    dbContext.State.Add(cd1);
                    
                }

            }

            dbContext.SaveChanges();
            ViewBag.dbSuccessComp = 1;
            return View("States", state);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
