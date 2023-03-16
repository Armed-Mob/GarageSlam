using GS.Server.Data;
using GS.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackablesController : ControllerBase
    {
        private readonly GSContext _context;

        public TrackablesController(GSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Trackable>>> GetAllTrackables()
        {
            var result = await _context.Trackables
                .ToListAsync();

            return result;
        }
    }
}
