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
    public class EpisodeController : ControllerBase
    {
        private readonly Context _context;
        private readonly IEpisodeService _episodeService;

        public EpisodeController(Context context, IEpisodeService episodeService)
        {
            _context = context;
            _episodeService = episodeService;
        }

       

        [HttpGet]
        public ActionResult<ApiResult<EpisodeDto>> GetEpisodes()
        {
            var episodes = _context.Episodes
                .Include(e => e.Characters)
                .ToList();

            var episodeDtos = episodes.Select(e => new EpisodeDto
            {
                Id = e.Id,
                Name = e.Name,
                AirDate = e.AirDate,
                EpisodeCode = e.EpisodeCode,
                Url = e.Url,
                Created = e.Created.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Characters = e.Characters.Select(c => c.Url).ToList()
            }).ToList();

            var apiResult = new ApiResult<EpisodeDto>
            {
                Info = new ApiInfo
                {
                    Count = episodeDtos.Count,
                    Pages = 1, // You may need to calculate the actual number of pages based on your pagination logic
                    Next = "https://yourapi.com/api/episode?page=2", // Set the next page URL here
                    Prev = null // Set the previous page URL here
                },
                Results = episodeDtos
            };

            return apiResult;
        }

        [HttpGet("{id}")]
        public ActionResult<EpisodeDto> GetEpisodeById(int id)
        {
            var episode = _context.Episodes
                .Include(e => e.Characters)
                .FirstOrDefault(e => e.Id == id);

            if (episode == null)
            {
                return NotFound(); // Return 404 if episode with the given ID is not found
            }

            var episodeDto = new EpisodeDto
            {
                Id = episode.Id,
                Name = episode.Name,
                AirDate = episode.AirDate,
                EpisodeCode = episode.EpisodeCode,
                Url = episode.Url,
                Created = episode.Created.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                Characters = episode.Characters.Select(c => c.Url).ToList()
            };

            return episodeDto;
        }

    }
}
