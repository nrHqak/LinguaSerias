using LinguaSeries.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinguaSeries.Services
{
    public class RecommendationService
    {
        public List<LearningItem> GetByLevel(IEnumerable<LearningItem> items, string level)
        {
            var normalized = NormalizeLevel(level);
            return items.Where(i => NormalizeLevel(i.Level) == normalized).ToList();
        }

        public List<LearningItem> Search(IEnumerable<LearningItem> items, string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return items.ToList();
            query = query.ToLowerInvariant();
            return items.Where(i => i.Title.ToLowerInvariant().Contains(query) || i.Genre.ToLowerInvariant().Contains(query)).ToList();
        }

        private string NormalizeLevel(string level)
        {
            if (level == "Beginner (A1)") return "A1";
            if (level == "Elementary (A2)") return "A2";
            if (level == "Intermediate (B1)") return "B1";
            if (level == "Upper-Intermediate (B2)") return "B2";
            if (level == "Advanced (C1)") return "C1";
            return level;
        }
    }
}
