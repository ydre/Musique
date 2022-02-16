using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musique.API.Ressources;
using Musique.Core.Models;
using Musique.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musique.API.Controllers
{
    [Route("api/Musique")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicService musicService;
        private readonly IMapper mapperService;
        public MusicController(IMusicService _musicService, IMapper _mapperService)
        {
            musicService = _musicService;
            mapperService = _mapperService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusic()
        {
            try
            {
                var musics = await musicService.GetAllWithArtist();
                var musicResources = mapperService.Map<IEnumerable<Music>, IEnumerable<MusicResource>>(musics);
                return Ok(musicResources);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MusicResource>> GetMusicById(int id)
        {
            try
            {
                var music = await musicService.GetMusicById(id);
                if (music == null) return NotFound();
                var musicResource = mapperService.Map<Music, MusicResource>(music);
                return Ok(musicResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
