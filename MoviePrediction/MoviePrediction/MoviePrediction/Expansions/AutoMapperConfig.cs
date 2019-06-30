using AutoMapper;
using MoviePrediction.Models;

namespace MoviePrediction.Expansions
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<IMovieIntro, HistoryPreview>().ForMember(preview => preview.TheMovieDbId, movie => movie.MapFrom(intro => intro.Id))
                                                            .ForMember(preview => preview.Id, movie => movie.Ignore());
            });
        }
    }
}
