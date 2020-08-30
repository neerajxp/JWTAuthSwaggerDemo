using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        public string GetProducts()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcomm To:" + userName;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<string>> GetAllValues()
        {
            return new string[] { "Value1", "Value2", "Value3" };
        }

        [Authorize]
        [HttpGet("GetOne")]
        public ActionResult<IEnumerable<string>> GetOneValue(int i)
        {
            return new string[] { "Value" + i };
        }
    }
}
