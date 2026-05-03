using LinguaSeries.UI;
using System.Drawing;
using System.Windows.Forms;

namespace LinguaSeries.UI.Controls
{
    public class ModernButton : Button
    {
        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Theme.Accent;
            ForeColor = Theme.Text;
            Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Height = 42;
            Cursor = Cursors.Hand;
            MouseEnter += (_, __) => BackColor = Theme.Hover;
            MouseLeave += (_, __) => BackColor = Theme.Accent;
        }
    }
}
