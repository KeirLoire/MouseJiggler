namespace MouseJiggler
{
    partial class Menu
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
            txtSeconds = new TextBox();
            lblSeconds = new Label();
            lblTitle = new Label();
            btnExit = new Button();
            lblAuthor = new Label();
            timerJiggle = new System.Windows.Forms.Timer(components);
            timerTimeout = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.BackColor = Color.FromArgb(66, 66, 66);
            btnStart.FlatAppearance.BorderSize = 0;
            btnStart.FlatStyle = FlatStyle.Flat;
            btnStart.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.ForeColor = Color.White;
            btnStart.Location = new Point(12, 131);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(238, 93);
            btnStart.TabIndex = 0;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // txtSeconds
            // 
            txtSeconds.Location = new Point(145, 96);
            txtSeconds.Name = "txtSeconds";
            txtSeconds.Size = new Size(105, 23);
            txtSeconds.TabIndex = 1;
            txtSeconds.Text = "5";
            // 
            // lblSeconds
            // 
            lblSeconds.AutoSize = true;
            lblSeconds.ForeColor = Color.White;
            lblSeconds.Location = new Point(12, 99);
            lblSeconds.Name = "lblSeconds";
            lblSeconds.Size = new Size(127, 15);
            lblSeconds.TabIndex = 2;
            lblSeconds.Text = "Idle Timeout (seconds)";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 37);
            lblTitle.TabIndex = 3;
            lblTitle.Text = "Mouse Jiggler";
            lblTitle.MouseDown += Drag_MouseDown;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Transparent;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(234, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 24);
            btnExit.TabIndex = 4;
            btnExit.TabStop = false;
            btnExit.Text = "X";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.ForeColor = Color.White;
            lblAuthor.Location = new Point(50, 46);
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
            // Menu
            // 
            AcceptButton = btnStart;
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(33, 33, 33);
            CancelButton = btnExit;
            ClientSize = new Size(262, 236);
            ControlBox = false;
            Controls.Add(lblAuthor);
            Controls.Add(btnExit);
            Controls.Add(lblTitle);
            Controls.Add(lblSeconds);
            Controls.Add(txtSeconds);
            Controls.Add(btnStart);
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Menu";
            Text = "Mouse Jiggler";
            MouseDown += Drag_MouseDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private TextBox txtSeconds;
        private Label lblSeconds;
        private Label lblTitle;
        private Button btnExit;
        private Label lblAuthor;
        private System.Windows.Forms.Timer timerJiggle;
        private System.Windows.Forms.Timer timerTimeout;
    }
}
