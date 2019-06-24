namespace MoviePrediction.Models
{
    public interface ICrew : IMember
    {
        string Department { get; set; }
        string Job { get; set; }
    }
}
