using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace BooksService.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class BooksController : ControllerBase
    {

        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [RequiredScopeOrAppPermission(AcceptedAppPermission = new[] { "Books.GetAll" })]
        [HttpGet(Name = "GetAll")]
        public IEnumerable<Book> GetAll()
        {
            return new List<Book>()
            {
                new Book(){ Name = "IT", Author = "Stephen King", NmPages = 1500 },
                new Book(){ Name = "Christine", Author = "Stephen King", NmPages = 367 }
            };
        }

        [RequiredScopeOrAppPermission(AcceptedAppPermission = new[] { "Books.Get" })]
        [HttpGet(Name = "Get")]
        public Book Get()
        {
            return new Book() { Name = "Cujo", Author = "Stephen King", NmPages = 865 };
        }
    }
}