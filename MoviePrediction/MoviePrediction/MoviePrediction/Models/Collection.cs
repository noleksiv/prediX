using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public class Collection: IEntity, ICollection, IPoster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        public Uri PosterUrl { get; set; }
        public Uri BackdropUrl { get; set; }
               
        public ICollection<IMovieIntro> Parts { get; set; }
    }
}
