namespace Randomizer.Controllers
{
    public partial class RandomizerController
    {
        static HttpClient client = new();


        static void Main()
        {
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
