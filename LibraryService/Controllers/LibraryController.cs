using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<Library> Get()
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.GetAsync("https://localhost:7205/books");
            var books = JsonConvert.DeserializeObject<List<Book>>(await response.Content.ReadAsStringAsync());

            return new Library
            {
                Name = "Iliev Talks Tech",
                Books = books
            };
        }
    }
}