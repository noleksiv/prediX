using MonkeyCache;
using MonkeyCache.SQLite;
using System;

namespace MoviePrediction.Services
{
    public class MonkeyCache
    {
        private const int _duration = 1;

        public IBarrel Cache { get => Barrel.Current; }

        public string GetCachedData(string url)
        {
            return Cache.Get<string>(key: url);
        }

        public void SaveData(string url, string json)
        {
            Cache.Add(key: url, data: json, expireIn: TimeSpan.FromDays(_duration));
        }
    }
}
