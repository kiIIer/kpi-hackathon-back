using Idk.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Idk.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController
{
    [HttpGet]
    public async Task<UserModel> WhoIAm()
    {
        return null;
    }
}