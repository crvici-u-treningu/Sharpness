namespace Sharpness
{
    partial class GameFinderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameMainList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // gameMainList
            // 
            this.gameMainList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameMainList.FormattingEnabled = true;
            this.gameMainList.Location = new System.Drawing.Point(0, 0);
            this.gameMainList.Name = "gameMainList";
            this.gameMainList.Size = new System.Drawing.Size(344, 441);
            this.gameMainList.TabIndex = 0;
            this.gameMainList.DoubleClick += new System.EventHandler(this.gameMainList_DoubleClick);
            // 
            // GameFinderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 441);
            this.Controls.Add(this.gameMainList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameFinderDialog";
            this.Text = "Sharpness: Multiple Games Found";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox gameMainList;
    }
}