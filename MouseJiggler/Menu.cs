using System.Runtime.InteropServices;

namespace MouseJiggler
{
    public partial class frmMenu : Form
    {
        private bool _isJiggling = false;
        private bool _toggle = false;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmMenu()
        {
            InitializeComponent();

            // Enable double buffering to prevent flickering when drawing custom backgrounds
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            timerJiggle.Interval = 1000;

            InputHook.UserActivity += OnUserActivity;
            InputHook.Start();

            // Apply glassmorphic control styles
            StyleControls();

            // Round the form corners dynamically
            this.Load += (s, e) => RoundFormCorners();
            this.SizeChanged += (s, e) => RoundFormCorners();
        }

        private void StyleControls()
        {
            // Title and author labels are handled in OnPaint
            lblTitle.Visible = false;
            lblAuthor.Visible = false;
            label1.Visible = false;

            // Style window control buttons
            btnExit.BackColor = Color.Transparent;
            btnExit.ForeColor = Color.White;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 219, 0, 255);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 255, 0, 100);

            btnMinimize.BackColor = Color.Transparent;
            btnMinimize.ForeColor = Color.White;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 255, 255, 255);
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 255, 255, 255);

            // Style TextBox
            txtIdleTimeout.BackColor = Color.FromArgb(10, 12, 28);
            txtIdleTimeout.ForeColor = Color.White;
            txtIdleTimeout.BorderStyle = BorderStyle.None;
            txtIdleTimeout.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);

            // Style Start Button
            UpdateButtonStyles();
        }

        private void UpdateButtonStyles()
        {
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.FlatAppearance.BorderSize = 1;

            if (_isJiggling)
            {
                btnStart.Text = "STOP";
                btnStart.BackColor = Color.FromArgb(40, 219, 0, 255); // Pink glass/glow
                btnStart.ForeColor = Color.White;
                btnStart.FlatAppearance.BorderColor = Color.FromArgb(150, 219, 0, 255);
                btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 219, 0, 255);
                btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 219, 0, 255);
            }
            else
            {
                btnStart.Text = "START";
                btnStart.BackColor = Color.FromArgb(40, 0, 242, 254); // Cyan glass/glow
                btnStart.ForeColor = Color.White;
                btnStart.FlatAppearance.BorderColor = Color.FromArgb(150, 0, 242, 254);
                btnStart.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 0, 242, 254);
                btnStart.FlatAppearance.MouseDownBackColor = Color.FromArgb(120, 0, 242, 254);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isJiggling)
            {
                _isJiggling = false;
                timerJiggle.Stop();
                timerTimeout.Stop();
            }
            else
            {
                _isJiggling = true;
                timerJiggle.Start();
                timerTimeout.Stop();
            }
            UpdateButtonStyles();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerJiggler_Tick(object sender, EventArgs e)
        {
            var offset = _toggle ? 2 : -2;
            _toggle = !_toggle;

            InputHook.SendJiggleInput(offset, offset);
        }

        private void timerTimeout_Tick(object sender, EventArgs e)
        {
            timerTimeout.Stop();

            if (_isJiggling)
            {
                timerJiggle.Start();
            }
        }

        private void OnUserActivity(object? sender, EventArgs e)
        {
            if (!_isJiggling)
                return;

            timerJiggle.Stop();
            timerTimeout.Interval = int.Parse(txtIdleTimeout.Text) * 1000;
            timerTimeout.Stop();
            timerTimeout.Start();
        }

        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void txtSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            // Sleek dark linear gradient background matching the personal site color system
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(7, 9, 19),      // Deep dark blue #070913
                Color.FromArgb(22, 10, 36),     // Deep dark violet #160a24
                45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // 1. Draw Title Text with Cyan-to-Pink gradient
            using (var titleBrush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(24, 20, 200, 37),
                Color.FromArgb(0, 242, 254),     // Cyan #00f2fe
                Color.FromArgb(219, 0, 255),     // Pink #db00ff
                0F))
            {
                using (Font titleFont = new Font("Segoe UI", 20F, FontStyle.Bold))
                {
                    g.DrawString("Mouse Jiggler", titleFont, titleBrush, 24, 16);
                }
            }

            // 2. Draw subtitle / tagline text
            using (Font subtitleFont = new Font("Segoe UI Semibold", 8.5F))
            {
                using (Brush subtitleBrush = new SolidBrush(Color.FromArgb(163, 166, 194))) // #a3a6c2
                {
                    g.DrawString("Stay online, while you sleep", subtitleFont, subtitleBrush, 26, 54);
                }
            }

            // 3. Draw glass setting card (Panel 1 container)
            DrawGlassCard(g, 12, 92, 143, 76, 12);

            // 4. Draw textbox slot background and border (inside the card)
            using (Brush textSlotBrush = new SolidBrush(Color.FromArgb(15, 10, 12, 28)))
            {
                FillRoundedRectangle(g, textSlotBrush, 20, 130, 127, 28, 6);
            }
            using (Pen textSlotBorder = new Pen(Color.FromArgb(30, 255, 255, 255), 1F))
            {
                DrawRoundedRectangle(g, textSlotBorder, 20, 130, 127, 28, 6);
            }

            // 5. Draw label "IDLE TIMEOUT (SEC)" inside the settings card
            using (Font cardLabelFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            {
                using (Brush cardLabelBrush = new SolidBrush(Color.FromArgb(163, 166, 194)))
                {
                    g.DrawString("IDLE TIMEOUT (SEC)", cardLabelFont, cardLabelBrush, 22, 104);
                }
            }

            // 6. Draw copyright footer text
            using (Font footerFont = new Font("Segoe UI", 7.5F, FontStyle.Bold))
            {
                using (Brush footerBrush = new SolidBrush(Color.FromArgb(100, 163, 166, 194)))
                {
                    g.DrawString("© KeirLoire", footerFont, footerBrush, 172, 178);
                }
            }

            // 7. Draw form outer thin glass highlight border
            using (Pen formBorderPen = new Pen(Color.FromArgb(40, 255, 255, 255), 1F))
            {
                DrawRoundedRectangle(g, formBorderPen, 0, 0, this.Width - 1, this.Height - 1, 16);
            }
        }

        private void DrawGlassCard(Graphics g, int x, int y, int w, int h, int r)
        {
            using (Brush cardBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
            {
                FillRoundedRectangle(g, cardBrush, x, y, w, h, r);
            }
            using (Pen cardPen = new Pen(Color.FromArgb(25, 255, 255, 255), 1F))
            {
                DrawRoundedRectangle(g, cardPen, x, y, w, h, r);
            }
        }

        private void RoundFormCorners()
        {
            this.Region = null;
            using (var path = GetRoundedRectanglePath(0, 0, this.Width, this.Height, 16))
            {
                this.Region = new Region(path);
            }
        }

        private void FillRoundedRectangle(Graphics g, Brush brush, int x, int y, int width, int height, int radius)
        {
            using (var path = GetRoundedRectanglePath(x, y, width, height, radius))
            {
                g.FillPath(brush, path);
            }
        }

        private void DrawRoundedRectangle(Graphics g, Pen pen, int x, int y, int width, int height, int radius)
        {
            using (var path = GetRoundedRectanglePath(x, y, width, height, radius))
            {
                g.DrawPath(pen, path);
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectanglePath(int x, int y, int width, int height, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(x, y, diameter, diameter, 180, 90);
            path.AddArc(x + width - diameter, y, diameter, diameter, 270, 90);
            path.AddArc(x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);
            path.AddArc(x, y + height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
