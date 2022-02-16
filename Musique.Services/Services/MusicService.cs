using Musique.Core;
using Musique.Core.Models;
using Musique.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Musique.Services.Services
{
     public class MusicService: IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MusicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Core.Models.Music> CreateMusic(Core.Models.Music newMusic)
        {
            await _unitOfWork.Musics.AddAsync(newMusic);
            await _unitOfWork.CommitAsync();
            return newMusic;
        }


        public async Task DeleteMusic(Core.Models.Music music)
        {
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Core.Models.Music>> GetAllWithArtist()
        {
            return await _unitOfWork.Musics
              .GetAllWithArtistAsync();
        }

        public async Task<Core.Models.Music> GetMusicById(int id)
        {
            return await _unitOfWork.Musics
                .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Core.Models.Music>> GetMusicsByArtistId(int artistId)
        {
            return await _unitOfWork.Musics
             .GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateMusic(Core.Models.Music musicToBeUpdated, Core.Models.Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;

            await _unitOfWork.CommitAsync();
        }


    }
}
