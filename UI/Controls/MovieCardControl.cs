using LinguaSeries.Models;
using LinguaSeries.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LinguaSeries.UI.Controls
{
    public class MovieCardControl : Panel
    {
        public event Action<LearningItem> DetailsClicked;
        public LearningItem Item { get; }

        public MovieCardControl(LearningItem item)
        {
            Item = item;
            Width = 220; Height = 310; Margin = new Padding(12);
            BackColor = Theme.Card;

            var title = new Label { Text = item.Title, ForeColor = Theme.Text, Font = new Font("Segoe UI", 11, FontStyle.Bold), Dock = DockStyle.Top, Height = 36 };
            var meta = new Label { Text = $"{item.Level} • ⭐ {item.Rating} • {item.Genre}", ForeColor = Theme.Muted, Dock = DockStyle.Top, Height = 40 };
            var details = new ModernButton { Text = "Details", Dock = DockStyle.Bottom };
            details.Click += (_, __) => DetailsClicked?.Invoke(Item);

            Controls.Add(details); Controls.Add(meta); Controls.Add(title);
            MouseEnter += (_, __) => { Width = 228; Height = 318; };
            MouseLeave += (_, __) => { Width = 220; Height = 310; };
        }
    }
}
