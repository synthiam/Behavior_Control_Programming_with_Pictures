namespace Programming_with_Pictures {
  partial class UCProgramItem {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.lblDelete = new System.Windows.Forms.Label();
      this.lblTitle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(82, 65);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // lblDelete
      // 
      this.lblDelete.AutoSize = true;
      this.lblDelete.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblDelete.Location = new System.Drawing.Point(0, 0);
      this.lblDelete.Name = "lblDelete";
      this.lblDelete.Size = new System.Drawing.Size(19, 19);
      this.lblDelete.TabIndex = 1;
      this.lblDelete.Text = "X";
      this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
      // 
      // lblTitle
      // 
      this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblTitle.Location = new System.Drawing.Point(82, 0);
      this.lblTitle.Name = "lblTitle";
      this.lblTitle.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
      this.lblTitle.Size = new System.Drawing.Size(179, 65);
      this.lblTitle.TabIndex = 2;
      this.lblTitle.Text = "label1";
      this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // UCProgramItem
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.lblTitle);
      this.Controls.Add(this.lblDelete);
      this.Controls.Add(this.pictureBox1);
      this.Name = "UCProgramItem";
      this.Size = new System.Drawing.Size(261, 65);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label lblDelete;
    private System.Windows.Forms.Label lblTitle;
  }
}
