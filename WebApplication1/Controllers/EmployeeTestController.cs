using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebApplication1.Controllers
{
    public class EmployeeTestController : Controller
    {
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7034/api/Default");
            var jsonString = await response.Content.ReadAsStringAsync();

            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("API Hatası: " + response.StatusCode);
                Console.WriteLine("Gelen veri: " + jsonString);
            }
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Class1 p)
        {
            var httpClient = new HttpClient();
            var jsonEmployee = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonEmployee, Encoding.UTF8, "application/json");
            var responseMessage = await httpClient.PostAsync("https://localhost:7250/api/Default/", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(p);
        }
    }

    public class Class1
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
