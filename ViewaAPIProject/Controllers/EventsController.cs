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
        public async Task<ActionResult<IEnumerable<ViewaSample>>> GetAll()
        {
            var events = _context.ViewaSamples.AsQueryable();
            return await events.ToListAsync();
        }


        [HttpGet("{dateSearchParams}", Name = "Search")]
        public async Task<ActionResult<IEnumerable<ViewaSample>>> GetEvents(DateSearchParams dateSearchParams)        
        {
            var events = _context.ViewaSamples.AsQueryable();

            if (dateSearchParams.FromDate != null)
                events = events.Where(x => x.EventDate >= dateSearchParams.FromDate);

            if (dateSearchParams.ToDate != null)
                events = events.Where(x => x.EventDate <= dateSearchParams.ToDate);

            return await events.ToListAsync();
        }
    }
}