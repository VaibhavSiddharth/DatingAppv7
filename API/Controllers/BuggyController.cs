using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;

        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var user = this._context.Users.Find(-1);
            if (user == null) return NotFound();
            return user;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {

            var user = this._context.Users.Find(-1);
            var thingtoReturn = user.ToString();
            return thingtoReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This is not good request");
        }
    }
}