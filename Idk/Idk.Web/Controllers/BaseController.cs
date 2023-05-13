using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

public class BaseController : ControllerBase
{
    protected int UserId => 3;
}