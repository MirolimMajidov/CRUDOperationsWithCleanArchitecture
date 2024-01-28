using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    public class BackpackController : BaseController<Backpack>
    {
        public BackpackController(ILogger<BackpackController> logger, IBackpackService service) : base(logger, service) { }
    }
}