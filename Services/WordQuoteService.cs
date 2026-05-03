using System;

namespace LinguaSeries.Services
{
    public class WordQuoteService
    {
        private readonly (string word, string translate, string sample)[] _words =
        {
            ("Binge-watch", "смотреть запоем", "We binge-watched the whole season."),
            ("Cliffhanger", "интригующая концовка", "The episode ended on a cliffhanger."),
            ("Subtle", "тонкий", "Her British accent is subtle but clear.")
        };

        private readonly string[] _quotes =
        {
            "Consistency beats talent.",
            "Learn English one episode at a time.",
            "Small steps every day create fluent speakers."
        };

        public (string word, string translate, string sample) GetDailyWord() => _words[DateTime.Now.Day % _words.Length];
        public string GetQuote() => _quotes[DateTime.Now.Millisecond % _quotes.Length];
    }
}
