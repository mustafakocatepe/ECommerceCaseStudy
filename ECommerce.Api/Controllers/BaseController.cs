using ECommerce.Application.Common.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(ResponseState<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }
            else
            {
                return new ObjectResult(response)
                {
                    StatusCode = response.StatusCode
                };
            }


        }
    }
}
