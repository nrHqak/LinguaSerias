using LinguaSeries.UI;
using System.Drawing;
using System.Windows.Forms;

namespace LinguaSeries.Forms
{
    public class SplashForm : Form
    {
        private readonly Timer _timer = new Timer();
        private readonly ProgressBar _progress = new ProgressBar();

        public SplashForm()
        {
            FormBorderStyle = FormBorderStyle.None; StartPosition = FormStartPosition.CenterScreen;
            Width = 520; Height = 280; BackColor = Theme.Bg;
            Controls.Add(new Label { Text = "LinguaSeries", ForeColor = Theme.Text, Font = new Font("Segoe UI", 24, FontStyle.Bold), AutoSize = true, Left = 150, Top = 80 });
            _progress.SetBounds(60, 200, 400, 18); Controls.Add(_progress);
            _timer.Interval = 30; _timer.Tick += (_, __) => { _progress.Value = _progress.Value < 100 ? _progress.Value + 2 : 100; if (_progress.Value == 100) Close(); };
            Shown += (_, __) => _timer.Start();
        }
    }
}
