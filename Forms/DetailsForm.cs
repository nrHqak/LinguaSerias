using LinguaSeries.Models;
using LinguaSeries.UI;
using LinguaSeries.UI.Controls;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LinguaSeries.Forms
{
    public class DetailsForm : Form
    {
        public DetailsForm(LearningItem item)
        {
            Text = item.Title; Width = 900; Height = 620; BackColor = Theme.Bg; StartPosition = FormStartPosition.CenterParent;
            Controls.Add(new Label { Text = item.Title, ForeColor = Theme.Text, Font = new Font("Segoe UI", 24, FontStyle.Bold), Left = 40, Top = 30, AutoSize = true });
            Controls.Add(new Label { Text = $"{item.Year} • {item.Genre} • ⭐ {item.Rating}", ForeColor = Theme.Muted, Left = 42, Top = 80, AutoSize = true });
            Controls.Add(new Label { Text = item.Description, ForeColor = Theme.Text, Left = 42, Top = 130, Width = 760, Height = 120 });
            Controls.Add(new Label { Text = "Why this level: " + item.LevelReason, ForeColor = Theme.Text, Left = 42, Top = 260, Width = 760, Height = 80 });
            Controls.Add(new Label { Text = "Vocabulary: " + string.Join(", ", item.VocabularyWords.Take(8)), ForeColor = Theme.Muted, Left = 42, Top = 360, Width = 760, Height = 100 });
            var watch = new ModernButton { Text = "WATCH NOW", Left = 42, Top = 500, Width = 180 };
            watch.Click += (_, __) => Process.Start(item.WatchLink);
            Controls.Add(watch);
        }
    }
}
