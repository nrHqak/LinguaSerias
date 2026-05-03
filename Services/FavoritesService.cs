using System.Collections.Generic;
using System.Linq;

namespace LinguaSeries.Services
{
    public class FavoritesService
    {
        private readonly DataService _dataService = new DataService();
        private const string Path = "Data/favorites.json";

        public HashSet<string> Load() => _dataService.LoadOrDefault(Path, new HashSet<string>());
        public void Save(HashSet<string> favorites) => _dataService.Save(Path, favorites);
    }
}
