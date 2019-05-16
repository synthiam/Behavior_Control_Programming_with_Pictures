namespace Programming_with_Pictures {
  partial class FormMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.btnAttachCamera = new System.Windows.Forms.Button();
      this.tbLog = new System.Windows.Forms.TextBox();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.btnClear = new System.Windows.Forms.Button();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(3, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(355, 239);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // btnAttachCamera
      // 
      this.btnAttachCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAttachCamera.Location = new System.Drawing.Point(3, 248);
      this.btnAttachCamera.Name = "btnAttachCamera";
      this.btnAttachCamera.Size = new System.Drawing.Size(135, 37);
      this.btnAttachCamera.TabIndex = 1;
      this.btnAttachCamera.Text = "Attach Camera";
      this.btnAttachCamera.UseVisualStyleBackColor = true;
      this.btnAttachCamera.Click += new System.EventHandler(this.button1_Click);
      // 
      // tbLog
      // 
      this.tbLog.Location = new System.Drawing.Point(3, 291);
      this.tbLog.Multiline = true;
      this.tbLog.Name = "tbLog";
      this.tbLog.Size = new System.Drawing.Size(331, 117);
      this.tbLog.TabIndex = 2;
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoScroll = true;
      this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
      this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 55);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(341, 353);
      this.flowLayoutPanel1.TabIndex = 3;
      this.flowLayoutPanel1.WrapContents = false;
      // 
      // btnClear
      // 
      this.btnClear.Dock = System.Windows.Forms.DockStyle.Top;
      this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClear.Location = new System.Drawing.Point(3, 18);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(341, 37);
      this.btnClear.TabIndex = 4;
      this.btnClear.Text = "&Clear";
      this.btnClear.UseVisualStyleBackColor = true;
      this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(144, 257);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(86, 21);
      this.checkBox1.TabIndex = 6;
      this.checkBox1.Text = "Learning";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.flowLayoutPanel1);
      this.groupBox1.Controls.Add(this.btnClear);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(382, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(347, 411);
      this.groupBox1.TabIndex = 7;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Instructions";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Controls.Add(this.checkBox1);
      this.panel1.Controls.Add(this.tbLog);
      this.panel1.Controls.Add(this.btnAttachCamera);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(382, 411);
      this.panel1.TabIndex = 8;
      // 
      // FormMain
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.ClientSize = new System.Drawing.Size(729, 411);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.panel1);
      this.Name = "FormMain";
      this.Text = "FormMain";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
      this.Load += new System.EventHandler(this.FormMain_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button btnAttachCamera;
    private System.Windows.Forms.TextBox tbLog;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.CheckBox checkBox1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel1;
  }
}