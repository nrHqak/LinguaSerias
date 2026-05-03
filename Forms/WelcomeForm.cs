using LinguaSeries.UI;
using LinguaSeries.UI.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace LinguaSeries.Forms
{
    public class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            Text = "LinguaSeries"; Width = 960; Height = 600; StartPosition = FormStartPosition.CenterScreen; BackColor = Theme.Bg;
            var title = new Label { Text = "LinguaSeries", ForeColor = Theme.Text, Font = new Font("Segoe UI", 34, FontStyle.Bold), AutoSize = true, Left = 300, Top = 140 };
            var slogan = new Label { Text = "Learn English through movies and TV shows", ForeColor = Theme.Muted, Font = new Font("Segoe UI", 14), AutoSize = true, Left = 240, Top = 220 };
            var btn = new ModernButton { Text = "Start Learning", Width = 220, Left = 360, Top = 300 };
            btn.Click += (_, __) => { Hide(); new LevelSelectionForm().ShowDialog(); Close(); };
            Controls.AddRange(new Control[] { title, slogan, btn });
        }
    }
}
