using LinguaSeries.UI;
using LinguaSeries.UI.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace LinguaSeries.Forms
{
    public class LevelSelectionForm : Form
    {
        private readonly string[] levels = { "Beginner (A1)", "Elementary (A2)", "Intermediate (B1)", "Upper-Intermediate (B2)", "Advanced (C1)" };
        public LevelSelectionForm()
        {
            Text = "Choose level"; Width = 1000; Height = 640; BackColor = Theme.Bg; StartPosition = FormStartPosition.CenterScreen;
            var panel = new FlowLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(40) };
            foreach (var level in levels)
            {
                var card = new Panel { Width = 170, Height = 170, BackColor = Theme.Card, Margin = new Padding(15) };
                var lbl = new Label { Text = level, ForeColor = Theme.Text, Font = new Font("Segoe UI", 10, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                card.Controls.Add(lbl);
                card.MouseEnter += (_, __) => card.BackColor = Theme.Hover;
                card.MouseLeave += (_, __) => card.BackColor = Theme.Card;
                EventHandler openMain = (_, __) => { Hide(); new MainForm(level).ShowDialog(); Close(); };
                card.Click += openMain;
                lbl.Click += openMain;
                panel.Controls.Add(card);
            }
            Controls.Add(panel);
        }
    }
}
