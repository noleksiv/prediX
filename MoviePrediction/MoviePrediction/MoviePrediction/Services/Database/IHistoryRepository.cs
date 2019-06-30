using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Services.Database
{
    interface IHistoryRepository<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        int DeleteItem(int id);
        int SaveItem(T item);
    }
}
