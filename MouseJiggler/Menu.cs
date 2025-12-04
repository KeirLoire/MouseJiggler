using System.Runtime.InteropServices;

namespace MouseJiggler
{
    public partial class frmMenu : Form
    {
        private bool _isJiggling = false;
        private bool _isSelfMove = false;
        private bool _toggle = false;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public frmMenu()
        {
            InitializeComponent();

            timerJiggle.Interval = 1000;

            InputHook.UserActivity += OnUserActivity;
            InputHook.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_isJiggling)
            {
                _isJiggling = false;
                btnStart.Text = "START";
                timerJiggle.Stop();
                timerTimeout.Stop();
            }
            else
            {
                _isJiggling = true;
                btnStart.Text = "STOP";
                timerJiggle.Start();
                timerTimeout.Stop();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timerJiggler_Tick(object sender, EventArgs e)
        {
            _isSelfMove = true;

            var cursorPosition = Cursor.Position;
            var offset = _toggle ? 5 : -5;

            _toggle = !_toggle;

            Cursor.Position = new Point(cursorPosition.X + offset, cursorPosition.Y + offset);

            Task.Delay(50).ContinueWith(_ => _isSelfMove = false);
        }

        private void timerTimeout_Tick(object sender, EventArgs e)
        {
            timerTimeout.Stop();

            if (_isJiggling)
            {
                timerJiggle.Start();
            }
        }

        private void OnUserActivity(object sender, EventArgs e)
        {
            if (_isSelfMove)
                return;

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
            frmMenu.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(42, 42, 42);
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnStart.BackColor = Color.FromArgb(42, 42, 42);
        }
    }
}
