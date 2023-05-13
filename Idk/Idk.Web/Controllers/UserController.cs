using Azure.Core;
using Idk.Application.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    [HttpGet]
    [Authorize]
    public async Task<string> GetUserId()
    {
        return UserId;
    }
}