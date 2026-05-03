using LinguaSeries.Models;
using LinguaSeries.Services;
using LinguaSeries.UI;
using LinguaSeries.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LinguaSeries.Forms
{
    public class MainForm : Form
    {
        private readonly string _level;
        private readonly DataService _data = new DataService();
        private readonly RecommendationService _rec = new RecommendationService();
        private readonly FavoritesService _fav = new FavoritesService();
        private readonly WordQuoteService _word = new WordQuoteService();
        private FlowLayoutPanel _cards;
        private TextBox _search;
        private List<LearningItem> _all;

        public MainForm(string level)
        {
            _level = level;
            Text = "LinguaSeries - Home"; Width = 1280; Height = 780; BackColor = Theme.Bg; StartPosition = FormStartPosition.CenterScreen;
            BuildLayout();
            LoadData();
        }

        private void BuildLayout()
        {
            var sidebar = new Panel { Width = 180, Dock = DockStyle.Left, BackColor = Color.FromArgb(18, 18, 30) };
            foreach (var t in new[] { "Home", "Recommended", "Favorites", "Progress", "Settings", "About" })
                sidebar.Controls.Add(new Label { Text = t, ForeColor = Theme.Text, Font = new Font("Segoe UI", 11), Dock = DockStyle.Top, Height = 46, Padding = new Padding(20, 12, 0, 0) });

            var top = new Panel { Height = 90, Dock = DockStyle.Top, BackColor = Theme.Bg };
            _search = new TextBox { Width = 360, Left = 210, Top = 30, BackColor = Theme.Card, ForeColor = Theme.Text, BorderStyle = BorderStyle.FixedSingle };
            _search.TextChanged += (_, __) => RenderCards(_rec.Search(_all, _search.Text));
            var profile = new Label { Text = $"User: Guest | Level: {_level}", ForeColor = Theme.Muted, Left = 900, Top = 35, AutoSize = true };
            var dw = _word.GetDailyWord();
            var banner = new Label { Text = $"Word of the day: {dw.word} ({dw.translate}) | {_word.GetQuote()}", ForeColor = Theme.Text, Left = 210, Top = 5, AutoSize = true };
            top.Controls.AddRange(new Control[] { banner, _search, profile });

            _cards = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(12), AutoScroll = true };
            Controls.Add(_cards); Controls.Add(top); Controls.Add(sidebar);
        }

        private void LoadData()
        {
            _all = _data.LoadItems("Data/movies.json");
            RenderCards(_rec.GetByLevel(_all, _level));
        }

        private void RenderCards(List<LearningItem> items)
        {
            _cards.Controls.Clear();
            foreach (var item in items)
            {
                var card = new MovieCardControl(item);
                card.DetailsClicked += i => new DetailsForm(i).ShowDialog();
                _cards.Controls.Add(card);
            }
        }
    }
}
