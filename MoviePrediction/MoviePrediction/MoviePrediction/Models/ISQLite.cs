using System;
using System.Collections.Generic;
using System.Text;

namespace MoviePrediction.Models
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
