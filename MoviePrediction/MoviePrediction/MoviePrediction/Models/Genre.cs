using MoviePrediction.Resources;

namespace MoviePrediction.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        static public string NameOfGenre(int genreId)
        {
            switch (genreId)
            {
                case 28:
                    return AppResources.ActionGenre;
                case 12:
                    return AppResources.AdventureGenre;
                case 16:
                    return AppResources.AnimationGenre;
                case 35:
                    return AppResources.ComedyGenre;
                case 80:
                    return AppResources.CrimeGenre;
                case 99:
                    return AppResources.DocumentaryGenre;
                case 18:
                    return AppResources.DramaGenre;
                case 10751:
                    return AppResources.FamilyGenre;
                case 14:
                    return AppResources.FantasyGenre;
                case 36:
                    return AppResources.HistoryGenre;
                case 27:
                    return AppResources.HorrorGenre;
                case 10402:
                    return AppResources.MusicGenre;
                case 9648:
                    return AppResources.MysteryGenre;
                case 10749:
                    return AppResources.RomanceGenre;
                case 878:
                    return AppResources.ScienceFictionGenre;
                case 10770:
                    return AppResources.TVMovieGenre;
                case 53:
                    return AppResources.ThrillerGenre;
                case 10752:
                    return AppResources.WarGenre;
                case 37:
                    return AppResources.WesternGenre;
                default:
                    return AppResources.OtherGenre;
            }
        }
    }
}