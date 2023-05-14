using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

public class BaseController : ControllerBase
{
    public string UserId => base.HttpContext.User.Identity?.Name 
        ?? throw new ArgumentNullException(nameof(base.HttpContext.User.Identity));
}