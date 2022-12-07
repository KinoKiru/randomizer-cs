using Microsoft.AspNetCore.Mvc;

namespace Randomizer.Controllers
{
    public partial class RandomizerController : Controller
    {
        static HttpClient client = new HttpClient();


        static void Main()
        {
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
