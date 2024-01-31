using ApiProject.BusinessLayer.Abstract;
using ApiProject.DataAccessLayer.Concrete;
using ApiProject.DtoLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILocationService _locationService;

        public LocationController(Context context, ILocationService staffService)
        {
            _context = context;
            _locationService = staffService;

        }

        [HttpGet]
        public ActionResult<LocationDtos> GetLocations()
        {
            var locations = _context.Locations
                .Include(l => l.Residents)
                .ToList();

            var locationDtos = locations.Select(l => new LocationDtos
            {
                Id = l.Id,
                Name = l.Name,
                Type = l.Type,
                Dimension = l.Dimension,

                Residents = l.Residents.Select(c => c.Url).ToList(),
                

                Url = l.Url,
                Created = l.Created
            }).ToList();

            return Ok(locationDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<LocationDtos> GetLocationById(int id)
        {
            var location = _context.Locations
                .Include(l => l.Residents)
                .FirstOrDefault(l => l.Id == id);

            if (location == null)
            {
                return NotFound();
            }

            var locationDto = new LocationDtos
            {
                Id = location.Id,
                Name = location.Name,
                Type = location.Type,
                Dimension = location.Dimension,
                Residents = location.Residents.Select(c => c.Url).ToList(),
                
                Url = location.Url,
                Created = location.Created
            };

            return Ok(locationDto);
        }





    }
}
