﻿using System;
using MoviePrediction.Helpers;
using MoviePrediction.Models;

namespace MoviePrediction.Services.Photo
{
    public enum BackdropSize
    {
        w300,
        w720,
        w1280,
        original
    }
    public enum PosterSize
    {
        w92,
        w154,
        w185,
        w342,
        w500,
        w780,
        original
    }

    ///// <summary>
    ///// Refers to the method CreatePosterLink
    ///// </summary>
    ///// <param name="path">Part of an image location on the server</param>
    ///// <param name="posterSize" value="PosterSize.w500">Size of a poster</param>
    ///// <returns></returns>
    //public delegate string PosterContributor(string path, PosterSize posterSize = PosterSize.w500);
    ///// <summary>
    ///// Refers to the method CreateBackdropLink
    ///// </summary>
    ///// <param name="path">Part of an image location on thr server</param>
    ///// <param name="backdropSize" value="BackdropSize.w1280">Size of a backing</param>
    ///// <returns></returns>
    //public delegate string BackdropContributor(string path, BackdropSize backdropSize = BackdropSize.w1280);

    //public class ImageUrl
    //{
    //    private const string _baseUrl = LinksContainer.TmdbAbsolute;

    //    public Uri CreatePosterLink(string partPath, PosterSize posterSize = PosterSize.w500)
    //    {
    //        var fullPath = $"{_baseUrl}{posterSize}{partPath}";
    //        var url = new Uri(fullPath);
    //        return url;
    //    }

    //    public Uri CreateBackdropLink(string partPath, BackdropSize backdropSize = BackdropSize.w1280)
    //    {
    //        var fullPath = $"{_baseUrl}{backdropSize}{partPath}";
    //        var url = new Uri(fullPath);
    //        return url;
    //    }

    //    public Uri CreatePosterLink(IPoster poster, PosterSize posterSize = PosterSize.w500) => CreatePosterLink(poster.PosterPath, posterSize);

    //    public Uri CreateBackdropLink(IPoster poster, BackdropSize backdropSize = BackdropSize.w720) => CreateBackdropLink(poster.PosterPath, backdropSize);
    //}

    public class PosterImage : AbstractImage
    {
        public Uri CreatePosterLink(string partPath, PosterSize posterSize = PosterSize.w500) => CreateImageLink(partPath, posterSize.ToString());
        public Uri CreatePosterLink(IPoster poster, PosterSize posterSize = PosterSize.w500) => CreatePosterLink(poster.PosterPath, posterSize);
    }

    public class BackdropImage : AbstractImage
    {
        public Uri CreateBackdropLink(string partPath, BackdropSize backdropSize = BackdropSize.w1280) => CreateImageLink(partPath, backdropSize.ToString());
        public Uri CreateBackdropLink(IPoster poster, BackdropSize backdropSize = BackdropSize.w720) => CreateBackdropLink(poster.PosterPath, backdropSize);
    }
}