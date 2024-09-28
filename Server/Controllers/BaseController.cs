using Microsoft.AspNetCore.Mvc;

namespace WhoKnowsApp.Server.Controllers
{
    public class BaseController<T> : ControllerBase
    {
        private ILogger<T> _logger;
        //private IMapper _mapper;
        //private User _appUser;
        //private ILiveUpdateService _services;

        protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();
        //protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
        //protected User AppUser => _appUser ??= new User { Id = User.FindFirstValue(ClaimTypes.NameIdentifier) };
        //protected ILiveUpdateService LiveUpdateService => _services ??= HttpContext.RequestServices.GetService<ILiveUpdateService>();

    }
}
