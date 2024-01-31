using ApiProject.DataAccessLayer.Concrete;
using ApiProject.DtoLayer.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ApiProject.BusinessLayer.Abstract;

namespace ApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly Context _context;
        private readonly ILogger<CharacterController> _logger;
        private readonly ICharacterService _characterService;

        public CharacterController(Context context, ILogger<CharacterController> logger, ICharacterService characterService)
        {
            _context = context;
            _logger = logger;
            _characterService = characterService;
        }

        [HttpGet]
        public ActionResult<ApiResult<CharacterDtos>> GetCharacters()
        {
            var characters = _context.Characters
                .Include(c => c.Episodes)
                .Include(c => c.Origin)
                .Include(c => c.Location)
                .ToList();

            var characterDtos = characters.Select(c => new CharacterDtos
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status,
                Species = c.Species,
                Type = c.Type,
                Gender = c.Gender,
                Image = c.Image,
                Episodes = c.Episodes.Select(e => e.Url).ToList(),
                Origin = new LocationDto
                {
                    Name = c.Origin?.Name,
                    Url = c.Origin?.Url
                },
                Location = new LocationDto
                {
                    Name = c.Location?.Name,
                    Url = c.Location?.Url
                },
                Url = c.Url,
                Created = c.Created
            }).ToList();

            var apiResult = new ApiResult<CharacterDtos>
            {
                Info = new ApiInfo
                {
                    Count = characterDtos.Count,
                    Pages = 1, // You may need to calculate the actual number of pages based on your pagination logic
                    Next = "https://yourapi.com/api/character?page=2", // Set the next page URL here
                    Prev = null // Set the previous page URL here
                },
                Results = characterDtos
            };

            return Ok(apiResult);
        }

        [HttpGet("{id}")]
        public ActionResult<CharacterDtos> GetCharacterById(int id)
        {
            var character = _context.Characters
                .Include(c => c.Episodes)
                .Include(c => c.Origin)
                .Include(c => c.Location)
                .FirstOrDefault(c => c.Id == id);

            if (character == null)
            {
                return NotFound(); // Return 404 if the character is not found
            }

            var characterDtos = new CharacterDtos
            {
                Id = character.Id,
                Name = character.Name,
                Status = character.Status,
                Species = character.Species,
                Type = character.Type,
                Gender = character.Gender,
                Image = character.Image,
                Origin = new LocationDto
                {
                    Name = character.Origin?.Name,
                    Url = character.Origin?.Url
                },
                Location = new LocationDto
                {
                    Name = character.Location?.Name,
                    Url = character.Location?.Url
                },
                //Episodes = character.Episodes.Select(e => e.Url).ToList(),
                //Episodes = character.Episodes.Select(c => new EpisodeDtos
                //{
                //    Url = c.Url
                //}).ToList(),

                Episodes = character.Episodes.Select(c => c.Url).ToList(),

                Url = character.Url,
                Created = character.Created
            };

            return Ok(characterDtos);
        }

    }
}
