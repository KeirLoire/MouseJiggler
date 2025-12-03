namespace MouseJiggler
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            txtIdleTimeout = new TextBox();
            lblTitle = new Label();
            btnExit = new Button();
            lblAuthor = new Label();
            timerJiggle = new System.Windows.Forms.Timer(components);
            timerTimeout = new System.Windows.Forms.Timer(components);
            grpIdleTimeout = new GroupBox();
            label1 = new Label();
            btnMinimize = new Button();
            grpIdleTimeout.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(66, 66, 66);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(170, 104);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(67, 57);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            btnStart.MouseHover += btnStart_MouseHover;
            // 
            // txtIdleTimeout
            // 
            txtIdleTimeout.Location = new Point(6, 22);
            txtIdleTimeout.Name = "txtIdleTimeout";
            txtIdleTimeout.Size = new Size(131, 23);
            txtIdleTimeout.TabIndex = 1;
            txtIdleTimeout.Text = "5";
            txtIdleTimeout.KeyPress += txtSeconds_KeyPress;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(29, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Mouse Jiggler";
            lblTitle.MouseDown += Drag_MouseDown;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(33, 33, 33);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(219, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 24);
            btnExit.TabIndex = 4;
            btnExit.TabStop = false;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseHover += btnExit_MouseHover;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = Color.White;
            lblAuthor.Location = new Point(49, 62);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(152, 15);
            lblAuthor.TabIndex = 5;
            lblAuthor.Text = "Stay online, while you sleep";
            lblAuthor.MouseDown += Drag_MouseDown;
            // 
            // timerJiggle
            // 
            timerJiggle.Tick += timerJiggler_Tick;
            // 
            // timerTimeout
            // 
            timerTimeout.Tick += timerTimeout_Tick;
            // 
            // grpIdleTimeout
            // 
            grpIdleTimeout.Controls.Add(txtIdleTimeout);
            grpIdleTimeout.ForeColor = Color.White;
            grpIdleTimeout.Location = new Point(12, 104);
            grpIdleTimeout.Name = "grpIdleTimeout";
            grpIdleTimeout.Size = new Size(143, 57);
            grpIdleTimeout.TabIndex = 9;
            grpIdleTimeout.TabStop = false;
            grpIdleTimeout.Text = "Idle Timeout (seconds)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(170, 178);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 10;
            label1.Text = "© KeirLoire";
            label1.MouseDown += Drag_MouseDown;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(33, 33, 33);
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(188, -1);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 24);
            btnMinimize.TabIndex = 11;
            btnMinimize.TabStop = false;
            btnMinimize.Text = "_";
            btnMinimize.TextAlign = ContentAlignment.TopCenter;
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            btnMinimize.MouseHover += btnMinimize_MouseHover;
            // 
            // frmMenu
            // 
            AcceptButton = btnStart;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(33, 33, 33);
            CancelButton = btnExit;
            ClientSize = new Size(249, 202);
            ControlBox = false;
            Controls.Add(btnMinimize);
            Controls.Add(label1);
            Controls.Add(grpIdleTimeout);
            Controls.Add(lblAuthor);
            Controls.Add(btnExit);
            Controls.Add(lblTitle);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "frmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mouse Jiggler";
            MouseDown += Drag_MouseDown;
            grpIdleTimeout.ResumeLayout(false);
            grpIdleTimeout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtIdleTimeout;
        private Label lblTitle;
        private Button btnExit;
        private Label lblAuthor;
        private System.Windows.Forms.Timer timerJiggle;
        private System.Windows.Forms.Timer timerTimeout;
        private GroupBox grpIdleTimeout;
        private Label label1;
        private Button btnMinimize;
    }
}
