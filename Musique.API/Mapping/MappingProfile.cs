using AutoMapper;
using Musique.API.Ressources;
using Musique.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musique.API.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Domain(base de donnée )  vers Resource
            CreateMap<Music, MusicResource>();
            CreateMap<Artist, ArtistResource>();
            //CreateMap<Music, SaveMusicResource>();
            //CreateMap<Artist, SaveArtistResource>();
            //CreateMap<Composer, ComposerResourse>();
            //CreateMap<Composer, SaveComposerResource>();

            // Resources vers Domain ou la base de données

            CreateMap<MusicResource, Music>();
            CreateMap<ArtistResource, Artist>();
            //CreateMap<SaveMusicResource, Music>();
            //CreateMap<SaveArtistResource, Artist>();
            //CreateMap<ComposerResourse, Composer>();
            //CreateMap<SaveComposerResource, Composer>();
        }


    }
}
