using LinguaSeries.Models;

namespace LinguaSeries.Services
{
    public class ProgressService
    {
        private readonly DataService _dataService = new DataService();
        private const string Path = "Data/progress.json";

        public UserProfile LoadProfile() => _dataService.LoadOrDefault(Path, new UserProfile());
        public void SaveProfile(UserProfile profile) => _dataService.Save(Path, profile);
    }
}
