namespace LinguaSeries.Models
{
    public class UserProfile
    {
        public string Username { get; set; } = "Guest";
        public string SelectedLevel { get; set; } = "A2";
        public int WatchedCount { get; set; }
        public string FavoriteGenre { get; set; } = "Comedy";
    }
}
