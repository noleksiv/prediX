using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using MoviePrediction.Models;

namespace MoviePrediction.Services.Database
{
    public class HistoryRepository: IHistoryRepository<HistoryPreview>
    {
        private const int _maxElements = 20;
        private SQLiteConnection _connection;

        public HistoryRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<HistoryPreview>();
        }
        public IEnumerable<HistoryPreview> GetItems()
        {
            return (from movie in _connection.Table<HistoryPreview>() select movie).ToList();

        }
        public HistoryPreview GetItem(int id)
        {
            return _connection.Get<HistoryPreview>(id);
        }
        public int DeleteItem(int id)
        {
            return _connection.Delete<HistoryPreview>(id);
        }
        public int SaveItem(HistoryPreview item)
        {
            if (item.Id != 0)
            {
                _connection.Update(item);
                return item.Id;
            }
            else
            {
                var result = _connection.Insert(item);
                DeleteNedless();
                return result;
            }
        }

        /// <summary>
        /// The method is used to restrict history to _maxElements items.
        /// </summary>
        private void DeleteNedless()
        {
            var historyLength = _connection.Table<HistoryPreview>().Count();

            if (historyLength > _maxElements)
            {
                var idForRemoving = _connection.Table<HistoryPreview>().First().Id;
                DeleteItem(idForRemoving);
            }                
        }
    }
}
