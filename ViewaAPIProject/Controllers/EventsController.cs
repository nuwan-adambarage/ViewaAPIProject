using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViewaAPIProject.Models;

namespace ViewaAPIProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ViewaSample>>> GetEvents(DateTime? startDate, DateTime? endDate)
        {
            var events = _context.ViewaSamples.AsQueryable();

            if (startDate != null)
                events = events.Where(x => x.EventDate >= startDate);

            if (endDate != null)
                events = events.Where(x => x.EventDate <= endDate);

            return await events.ToListAsync();
        }
    }
}