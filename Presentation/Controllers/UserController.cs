using Application.Services;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    public class UserController : BaseController<User>
    {
        public UserController(ILogger<UserController> logger, IUserService service) : base(logger, service) { }
    }
}