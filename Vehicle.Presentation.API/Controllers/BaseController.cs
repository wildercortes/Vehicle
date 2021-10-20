using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vehicle.Presentation.API.Helpers.Models;

namespace Vehicle.Presentation.API.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected StatusCodeResult OkNoContent()
        {
            return StatusCode((int)HttpStatusCode.NoContent);
        }

        protected new OkObjectResult Ok(object value)
        {
            return base.Ok(new HttpSuccess(value));
        }
    }
}
