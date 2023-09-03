

using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseAPIController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]

        public ActionResult GetNotFoundRequest()
        {
            var thing=_context.Products.Find(98);

            if (thing == null)
            {
                return NotFound(new APIResponse(404));
            }
            return Ok();
        }
        
        [HttpGet("servererror")]

        public ActionResult GetServerErrorRequest()
        {
            var thing=_context.Products.Find(98);

            var thingtoReturn= thing.ToString();

            return Ok();
        }

        [HttpGet("badrequest")]

        public ActionResult GetBadRequest()
        {
            return BadRequest(new APIResponse(400));
        }

        [HttpGet("badrequest/{id}")]

        public ActionResult GetBadRequest(int id)
        {
            return BadRequest(id);
        }
    }
}